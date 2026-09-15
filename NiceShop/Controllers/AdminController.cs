using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NiceShop.Data;
using NiceShop.Models;

namespace NiceShop.Controllers;
[Authorize (Roles = "Admin")]
public class AdminController: Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    // GET: Admin/Products
    public async Task<IActionResult> Products(string? searchName, string? category, string? isActive, string? stockStatus)
    {
        var query = _context.Products
        .Include(p => p.Category)
        .Include(p => p.Brand)
        .Include(p => p.Images)
        .Include(p => p.Colors)
        .Include(p => p.Sizes)
        .AsQueryable();

        if(!string.IsNullOrWhiteSpace(searchName))
            query = query.Where(p=>p.Name.Contains(searchName));

        if(!string.IsNullOrWhiteSpace(category))
            query = query.Where(p=>p.Category.Name == category);

        if(!string.IsNullOrWhiteSpace(isActive))
            query = query.Where(p=>p.IsActive == (isActive == "active" ? true : false));

        if(!string.IsNullOrWhiteSpace(stockStatus))
        {
            if (stockStatus == "in")
                query = query.Where(p => p.Stock > 0);
            else if (stockStatus == "out")
                query = query.Where(p => p.Stock <= 0);
        }
       
        var products = await query.ToListAsync();
        ViewBag.Categories = await _context.Categories.Select(c => c.Name).Distinct().ToListAsync();

        return View(products);
    }

    // GET: Admin/AddProduct
    public async Task<IActionResult> AddProduct()
    {
        await PopulateDropdowns();
        return View();
    }

    // POST: Admin/AddProduct
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(Product product, List<int> sizeIds, List<int> colorIds, List<IFormFile> imageFiles)
    {
        if (ModelState.IsValid)
        {
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            if(colorIds!=null && colorIds.Any())
            {
                product.Colors = await _context.Colors.Where(c=> colorIds.Contains(c.Id)).ToListAsync();
            }
            if(sizeIds != null && sizeIds.Any())
            {
                product.Sizes = await _context.Sizes.Where(s=> sizeIds.Contains(s.Id)).ToListAsync();
            }

            if(imageFiles!=null && imageFiles.Count>0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "products");
                Directory.CreateDirectory(uploadsFolder);
                bool isFirst = true;
                foreach(var file in imageFiles)
                {
                    if(file.Length>0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string physicalPath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream); 
                        }

                        var img = new Image
                        {
                            Name = file.FileName,
                            FilePath = "/assets/products/" + uniqueFileName,
                            IsDefault = isFirst,
                            Type = isFirst?ImageType.Thumbnail:ImageType.Gallery
                        };

                        product.Images.Add(img);
                        isFirst = false;
                    }
                }
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Product '{product.Name}' added successfully!";

            return RedirectToAction(nameof(AddProduct));
        }

        await PopulateDropdowns(product.CategoryId, product.BrandId);
        return View(product);
    }

    // GET: Admin/EditProduct/5
    public async Task<IActionResult> EditProduct(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .Include(p=>p.Brand)
            .Include(p=>p.Category)
            .Include(p=>p.Colors)
            .Include(p=>p.Sizes)
            .Include(p=>p.Images)
            .FirstOrDefaultAsync(p=>p.Id == id);
        if (product == null)
        {
            return NotFound();
        }


        await PopulateDropdowns(product.CategoryId, product.BrandId);
        return View(product);
    }

    // POST: Admin/EditProduct/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProduct(int id, Product product, List<int> sizeIds, List<int> colorIds, List<IFormFile> imageFiles , int stock)
    {
        if (id != product.Id)
        {
            return NotFound();
        }
         if(ModelState.IsValid)
        {
            var currentProduct = await _context.Products
                .Include(p=>p.Brand)
            .Include(p=>p.Category)
                .Include(p=>p.Colors)
                .Include(p=>p.Sizes)
            .Include(p=>p.Images)
            .FirstOrDefaultAsync(p=>p.Id == id);

            if(currentProduct == null)
            {
                return NotFound();
            }
        
            _context.Entry(currentProduct).CurrentValues.SetValues(product);
            currentProduct.UpdatedAt = DateTime.Now;

            currentProduct.Colors.Clear();

            if(colorIds!=null && colorIds.Any())
            {
                currentProduct.Colors = await _context.Colors.Where(c=> colorIds.Contains(c.Id)).ToListAsync();
            }
            currentProduct.Sizes.Clear();
            if(sizeIds != null && sizeIds.Any())
            {
                currentProduct.Sizes = await _context.Sizes.Where(s=> sizeIds.Contains(s.Id)).ToListAsync();
            }
            
            if(imageFiles!=null && imageFiles.Count>0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "products");
                Directory.CreateDirectory(uploadsFolder);
                bool isFirst = !currentProduct.Images.Any();
                foreach(var file in imageFiles)
                {
                    if(file.Length>0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string physicalPath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream); 
                        }

                        var img = new Image
                        {
                            Name = file.FileName,
                            FilePath = "/assets/products/" + uniqueFileName,
                            IsDefault = isFirst,
                            Type = isFirst?ImageType.Thumbnail:ImageType.Gallery
                        };

                        currentProduct.Images.Add(img);
                        isFirst = false;
                    }
                
                }
            
            }
                await _context.SaveChangesAsync();
                product.UpdatedAt = DateTime.Now;

                TempData["EditMessage"] = $"Product '{product.Name}' was updated successfully!";
                return RedirectToAction(nameof(EditProduct), product.Id);


        }
    
        await PopulateDropdowns(product.CategoryId, product.BrandId);
        return View(product);
    }

    // POST: Admin/DeleteProduct
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Products));
    }

    //delete selected products
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> DeleteSelected(List<int> ids)
    {
        var products = await _context.Products.Where(p=>ids.Contains(p.Id)).ToListAsync();
        if(products!=null && products.Count>0)
        {
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Products));
    }
/* ==========================================*/
    public IActionResult Orders()
    {
        return View();
    }

    public IActionResult Reviews()
    {
        return View();
    }

/* ====================Categories======================*/

    // GET: Admin/CategoriesCoupons
    public async Task<IActionResult> Categories()
    {
        var categories = await _context.Categories.Include(c=>c.Image).ToListAsync();
        return View(categories);
    }

    // POST: Admin/AddCategory
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddCategory(string name, string slug, IFormFile? imageFile)
    {
        bool exists = await _context.Categories.AnyAsync(c => c.Name == name);
        if (!exists && !string.IsNullOrWhiteSpace(name))
        {
            var cat = new Category() {Name = name, Slug = slug};
            if(imageFile != null && imageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "categories");
                 Directory.CreateDirectory(uploadsFolder);

                 string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                 string physicalPath = Path.Combine(uploadsFolder, uniqueFileName);

                 using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                var img = new Image
                {
                    Name = imageFile.FileName,
                    FilePath = "/assets/categories/" + uniqueFileName,
                    IsDefault = true, 
                    Type = ImageType.Thumbnail
                };
                cat.Image = img;
            }
            
            _context.Categories.Add(cat);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Categories));
    }

    // POST: Admin/DeleteCategory
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        bool has_products = await _context.Products.AnyAsync(p=>p.CategoryId == id);

        if(!has_products)
        {
            var category = await _context.Categories.FindAsync(id);
            
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

        }
        else
        {
            TempData["ErrorMessage"] = $"There are products in this category, delete them first!";
        }
        return RedirectToAction(nameof(Categories));

    }

    //Edit category
    public async Task<IActionResult> EditCategory(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var category = await _context.Categories
            .Include(c => c.Image)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> EditCategory(int? id, Category category, IFormFile? imageFile)
    {
        if(!ModelState.IsValid)
        {
            return View(category);
        }
        var currentCategory = await _context.Categories.Include(c=>c.Image).FirstOrDefaultAsync(c=>c.Id == id);

        if(currentCategory == null) return NotFound();
        currentCategory.Name = category.Name;
        currentCategory.Slug = category.Slug;

        if (imageFile != null && imageFile.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "categories");
            Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string physicalPath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(physicalPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            var newImg = new Image
            {
                Name = imageFile.FileName,
                FilePath = "/assets/categories/" + uniqueFileName,
                IsDefault = true,
                Type = ImageType.Thumbnail
            };

            currentCategory.Image = newImg;
        }
            
        
         await _context.SaveChangesAsync();
         TempData["CategorySuccessMessage"] = $"Category updated successfully!";
        return View(category);
    }


   // GET: Admin/Brands
    public async Task<IActionResult> Brands()
    {
        var brands = await _context.Brands.Include(b=>b.Image).ToListAsync();
        return View(brands);
    }

    // POST: Admin/AddBrand
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddBrand(string name, string country, IFormFile? imageFile)
    {
        bool exists = await _context.Brands.AnyAsync(b => b.Name == name);
        if (!exists && !string.IsNullOrWhiteSpace(name))
        {
            var brand = new Brand() {Name = name, Country = country};
            if(imageFile != null && imageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "brands");
                 Directory.CreateDirectory(uploadsFolder);

                 string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                 string physicalPath = Path.Combine(uploadsFolder, uniqueFileName);

                 using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                var img = new Image
                {
                    Name = imageFile.FileName,
                    FilePath = "/assets/brands/" + uniqueFileName,
                    IsDefault = true, 
                    Type = ImageType.Thumbnail
                };
                brand.Image = img;
            }
            
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Brands));
    }

    // POST: Admin/DeleteBrand
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        bool has_products = await _context.Products.AnyAsync(p=>p.BrandId == id);

        if(!has_products)
        {
            var brand = await _context.Brands.FindAsync(id);
            
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }

        }
        else
        {
            TempData["ErrorMessage"] = $"The brand has some products, delete them first!";
        }
        return RedirectToAction(nameof(Brands));

    }

    //Edit brand
    public async Task<IActionResult> EditBrand(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var brand = await _context.Brands
            .Include(b => b.Image)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (brand == null) return NotFound();
        return View(brand);
    }

    [HttpPost]
    public async Task<IActionResult> EditBrand(int? id, Brand brand, IFormFile? imageFile)
    {
        if(!ModelState.IsValid)
        {
            return View(brand);
        }
        var currentBrand = await _context.Brands.Include(b=>b.Image).FirstOrDefaultAsync(b=>b.Id == id);

        if(currentBrand == null) return NotFound();
        currentBrand.Name = brand.Name;
        currentBrand.Country = brand.Country;

        if (imageFile != null && imageFile.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "brands");
            Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string physicalPath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(physicalPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            var newImg = new Image
            {
                Name = imageFile.FileName,
                FilePath = "/assets/brands/" + uniqueFileName,
                IsDefault = true,
                Type = ImageType.Thumbnail
            };

            currentBrand.Image = newImg;
        }
            
        
         await _context.SaveChangesAsync();
         TempData["BrandSuccessMessage"] = $"Brand updated successfully!";
        return View(brand);
    }
    private async Task PopulateDropdowns(int? selectedCategoryId = null, int? selectedBrandId = null)
    {
        ViewBag.CategoryId = new SelectList(
            await _context.Categories.ToListAsync(), "Id", "Name", selectedCategoryId);

        ViewBag.BrandId = new SelectList(
            await _context.Brands.ToListAsync(), "Id", "Name", selectedBrandId);

        ViewBag.Colors = await _context.Colors.ToListAsync();
        ViewBag.Sizes = await _context.Sizes.ToListAsync();
    }
}