# Developer 1: Catalog & Customer Experience Guide

Welcome to the team! You own the core shopping experience: the Product Catalog, Search, Filtering, and the Admin tools to manage those products.

## Git & GitHub Workflow for Beginners
We are keeping things simple using a Two-Branch Workflow (`main` and `feature` branches). **Never write code directly on the `main` branch.**

1. **Start Fresh:** Always get the latest code before starting a task.
   ```bash
   git checkout main
   git pull origin main
   ```
2. **Create Your Feature Branch:** Name it after your task (e.g., DEV1-01).
   ```bash
   git checkout -b DEV1-01-entities
   ```
3. **Write Code & Commit:** Save your work as you go.
   ```bash
   git add .
   git commit -m "Added Product and Category Entities"
   ```
4. **Push to GitHub:**
   ```bash
   git push -u origin DEV1-01-entities
   ```
5. **Create a Pull Request (PR):** Go to GitHub, click "Compare & pull request", and merge your feature branch into `main`. Once merged, go back to step 1 for your next task!

---

## Your Tasks & Frontend Integration Guide

This frontend template provides the visual structure. Your job is to connect it to a real C# ASP.NET Core backend and SQL database.

### 1. Entities & DbContext (DEV1-01)
**Goal:** Setup Entity Framework Core.
**Guidance:** Create your `Product` and `Category` C# class models. Configure your `DbContext`. No frontend work needed here, but look at `SeedData.cs` to see what properties the template expects (Price, OriginalPrice, ImagesJson, Stock, etc.).

### 2. Catalog CRUD (DEV1-02)
**Goal:** Allow admins to Add, Edit, and Delete products and categories.
**Relevant Views:**
- `Views/Admin/Products.cshtml` (List of products)
- `Views/Admin/AddProduct.cshtml` (Form to add a product)
- `Views/Admin/CategoriesCoupons.cshtml` (Manage Categories)
**Guidance:** You'll need to create standard GET/POST Controller actions. The `AddProduct.cshtml` form is already set up to `POST` to `/Admin/AddProduct`. Hook that up to Entity Framework to save the new product.

### 3. Search & Filter (DEV1-03)
**Goal:** Let users find products.
**Relevant Views:** 
- `Views/Products/Index.cshtml` (The Shop page)
**Guidance:** Look at the sidebar in `Products/Index.cshtml`. The checkboxes and search bars are currently static HTML. You will need to wrap them in a `<form>` that does a `GET` request to your controller, e.g., `/Products?category=Shoes&sort=PriceAsc`. Then, use LINQ in your controller to filter the database results and pass them back to the view.

### 4. Product Details & Images (DEV1-04)
**Goal:** Display a single product and handle image uploads.
**Relevant Views:**
- `Views/Products/Details.cshtml` (The individual product page)
**Guidance:** In `Details.cshtml`, replace the static `<img>` tags with a `foreach` loop that reads the image URLs from your database. In the Admin `AddProduct` process, handle the `IFormFile` upload to save files to the `wwwroot/images/products/<ProductName>/` folder (refer to the `INTEGRATION_GUIDE` or Walkthrough for the C# snippet).

### 5. Reviews & Related Products (DEV1-05)
**Goal:** Show reviews and "You May Also Like" items.
**Relevant Views:**
- `Views/Products/Details.cshtml`
**Guidance:** For related products, randomly select or match 4 products from the same category and pass them in the ViewModel. For reviews, you will need to wait for **Dev 3** to finish the Auth system so you can tie a Review to an `ApplicationUser`.

### 6. Admin Refinement (DEV1-06)
**Goal:** Polish the Admin experience.
**Guidance:** Add pagination to `Products.cshtml` if the list gets too long. Add validation logic (e.g., a product must have a price > 0). Use ASP.NET Core `ModelState.IsValid` and display validation errors in the views.

Good luck! Coordinate closely with Dev 3 when you need to secure your Admin pages.
