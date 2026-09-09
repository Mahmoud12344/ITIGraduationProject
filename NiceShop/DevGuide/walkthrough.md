# NiceShop MVC Template Conversion — Walkthrough

I have successfully converted the NiceShop React SPA into a pure, ready-to-use ASP.NET Core MVC template structure. All the files have been written to the `mvc-template` directory within your project folder. 

## What was accomplished

I completely stripped away the React, Vite, and Tailwind dependencies. What remains is a pure HTML, CSS, JavaScript, and C# setup that you can easily copy and paste into your own ASP.NET Core MVC project.

### 1. The Structure

The `mvc-template/` directory is organized just like a standard ASP.NET Core project:

- **`Models/`**: C# classes representing database tables (`Product`, `Order`, `Category`, etc.).
- **`ViewModels/`**: C# classes tailored for specific views (`HomeViewModel`, `CheckoutViewModel`, etc.).
- **`Controllers/`**: Stubbed C# controllers (`HomeController`, `ProductsController`, `AdminController`, etc.) that return the views and pass in data from `SeedData.cs`.
- **`Data/`**: Contains `SeedData.cs`, which provides static, in-memory mock data so you can run the views and see them populated without needing a database right away.
- **`Views/`**: The `.cshtml` Razor views.
  - **`Shared/`**: Contains `_Layout.cshtml` (storefront), `_AdminLayout.cshtml` (admin), and the `Partials/` folder (Header, Footer, Cart Drawer, AI Widget, etc.).
  - **`Home/`, `Products/`, `Cart/`, `Checkout/`, `Orders/`, `Admin/`, etc.**: The main views for the application.
- **`wwwroot/`**: The static assets.
  - **`css/niceshop.css`**: The master stylesheet, featuring light/dark mode variables and Bootstrap overrides.
  - **`css/niceshop-ai-widget.css`**: Isolated styles for the AI Stylist.
  - **`js/niceshop.js`**: Vanilla JS for storefront interactivity (theme toggling, search dropdowns, flash sale countdown).
  - **`js/niceshop-admin.js`**: Vanilla JS for admin panel interactions.
  - **`js/niceshop-ai-widget.js`**: Vanilla JS for the AI chat window.

### 2. Key Features Implemented

> [!TIP]
> **Light / Dark Mode**
> The template fully supports theming. The toggle switch in the header (and admin sidebar) will flip the `<html data-theme="dark">` attribute and save the preference to `localStorage`. The entire UI, including Bootstrap components, will seamlessly transition thanks to the CSS variables in `niceshop.css`.

> [!NOTE]
> **AI Stylist Widget**
> The AI widget has been converted to vanilla HTML/JS/CSS. It features typing indicators, product recommendation cards, and suggestion pills. 
> *As requested, the photo upload feature was removed.* To integrate it with your backend, you just need to uncomment and wire up the `fetch` call inside `wwwroot/js/niceshop-ai-widget.js` to point to your `/api/AI/Chat` endpoint.

> [!IMPORTANT]
> **Bootstrap 5 Foundation**
> Since you are familiar with the default .NET MVC Bootstrap template, I rebuilt the Tailwind designs using standard Bootstrap 5 classes wherever possible (e.g., `row`, `col-md-6`, `d-flex`, `mt-4`). For highly custom visuals (like the glassmorphic AI widget or specific hover animations), I wrote custom CSS in `niceshop.css`.

## How to use this in your project

1. **Copy the Files**: Simply drag and drop the `Models`, `ViewModels`, `Controllers`, `Views`, and `wwwroot` folders from `mvc-template/` directly into your existing ASP.NET Core MVC project.
2. **Update Namespaces**: If your project has a different namespace than `NiceShop`, you'll want to do a global find-and-replace to change `namespace NiceShop` to `namespace YourProjectName`.
3. **Database Integration**: The `SeedData.cs` file is just for demonstration. You will eventually want to create an Entity Framework `DbContext`, wire up your Models to a real database (like SQL Server), and update the Controllers to fetch data from the DB instead of the `SeedData` class.

## Conditionally Hiding the Admin Button
Right now, the "Admin" button in the top navigation is always visible. Since you will be implementing your own authentication and backend, you can easily wrap this button in a Razor `if` statement to check if the user is an admin.

Open `Views/Shared/Partials/_Header.cshtml` and locate the Admin button (around line 118). Wrap it in an authorization check like this:

```html
@if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
{
    <a href="@Url.Action("Dashboard", "Admin")" class="ns-nav-link d-flex align-items-center gap-1" style="color: #0ea5e9;">
        <i class="bi bi-shield-lock"></i>
        <span>Admin</span>
    </a>
}
```

Let me know if you would like me to adjust any of the styles, or if you need help taking the next steps to integrate this into your backend!

## Handling File Uploads in C# (Add Product)
In the Admin "Add Product" view, I replaced the JSON text area with a native multi-file drag-and-drop input field named `Images`. 

To handle this in your actual C# backend, you should update your POST action in the Controller to accept `List<IFormFile> Images`. Here is a standard implementation for saving those files to your `wwwroot/images/products` folder:

```csharp
[HttpPost]
public async Task<IActionResult> AddProduct(Product product, List<IFormFile> Images)
{
    if (ModelState.IsValid)
    {
        var imageUrls = new List<string>();
        
        // Sanitize the product name to create a safe folder name
        string safeProductName = string.Join("_", product.Name.Split(Path.GetInvalidFileNameChars()));
        
        // Target folder: wwwroot/images/products/ProductName/
        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products", safeProductName);
        
        // Ensure folder exists
        Directory.CreateDirectory(uploadsFolder);

        foreach (var file in Images)
        {
            if (file.Length > 0)
            {
                // Create a unique filename (or just use the original file name if preferred)
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save to disk
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Add the relative URL to your database list
                imageUrls.Add($"/images/products/{safeProductName}/{uniqueFileName}");
            }
        }

        // Convert the list to JSON and save to your model
        product.ImagesJson = System.Text.Json.JsonSerializer.Serialize(imageUrls);

        // _context.Products.Add(product);
        // await _context.SaveChangesAsync();
        
        return RedirectToAction("Products");
    }
    return View(product);
}
```
*Note: Make sure your `<form>` tag in `AddProduct.cshtml` includes `enctype="multipart/form-data"` when you integrate this so the browser actually sends the files!*
