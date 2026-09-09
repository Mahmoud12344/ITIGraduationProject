# Developer 2: Cart, Checkout & Orders Guide

Welcome to the team! You own the transaction lifecycle: everything from adding items to the cart, processing checkout, and managing order history.

## Git & GitHub Workflow for Beginners
We are keeping things simple using a Two-Branch Workflow (`main` and `feature` branches). **Never write code directly on the `main` branch.**

1. **Start Fresh:** Always get the latest code before starting a task.
   ```bash
   git checkout main
   git pull origin main
   ```
2. **Create Your Feature Branch:** Name it after your task (e.g., DEV2-01).
   ```bash
   git checkout -b DEV2-01-cart-entities
   ```
3. **Write Code & Commit:** Save your work as you go.
   ```bash
   git add .
   git commit -m "Added Cart and Order Entities"
   ```
4. **Push to GitHub:**
   ```bash
   git push -u origin DEV2-01-cart-entities
   ```
5. **Create a Pull Request (PR):** Go to GitHub, click "Compare & pull request", and merge your feature branch into `main`. Once merged, go back to step 1 for your next task!

---

## Your Tasks & Frontend Integration Guide

Your job is to take the static HTML shopping cart and checkout flows and make them fully functional by connecting them to a C# ASP.NET Core backend.

### 1. Entities & Migrations (DEV2-01)
**Goal:** Setup Entity Framework Core tables.
**Guidance:** Create `Cart`, `CartItem`, `Order`, and `OrderItem` C# classes. Run EF Migrations to generate the tables. A CartItem needs to store a reference to the `ProductId` (which Dev 1 is building), Quantity, Size, and Color.

### 2. Cart Persistence (DEV2-02)
**Goal:** Remember what's in the user's cart.
**Guidance:** You need to decide how to store the cart before checkout. The easiest ASP.NET Core approach is to use Session State (`HttpContext.Session`). For logged-in users, you can store it in the database.

### 3. Cart UI & Logic (DEV2-03)
**Goal:** Make the Shopping Bag interactive.
**Relevant Views:**
- `Views/Cart/Index.cshtml` (Shopping Bag page)
- `Views/Products/Details.cshtml` (Add to Cart form)
**Guidance:** In `Details.cshtml`, there is a `<form action="/Cart/Add">`. Hook this up to a `CartController`. In `Cart/Index.cshtml`, replace the static mock items with a `foreach` loop over the user's actual cart items. To handle the `+` and `-` quantity buttons, you can either wrap them in a small `<form>` that POSTs an update to the server, or use JavaScript (AJAX/Fetch) to call a C# API endpoint without reloading the page.

### 4. Checkout Validation (DEV2-04)
**Goal:** Validate addresses and coupons.
**Relevant Views:**
- `Views/Checkout/Index.cshtml`
**Guidance:** The checkout form needs a POST action. Create a C# ViewModel for the checkout form (First Name, Address, City, etc.). Use Data Annotations (`[Required]`, `[EmailAddress]`) on your C# model so ASP.NET handles the server-side validation for you. Dev 3 is building the Coupons system, so you will eventually need to query their `Coupons` table to validate discount codes.

### 5. Payment & Order (DEV2-05)
**Goal:** Finalize the transaction.
**Relevant Views:**
- `Views/Checkout/Index.cshtml`
- `Views/Checkout/Success.cshtml`
**Guidance:** For now, simulate the payment. When the checkout form is submitted, convert the `Cart` into an `Order` in the database, calculate the final Total, clear the user's Cart, and redirect them to `Checkout/Success`.

### 6. Admin Orders & History (DEV2-06)
**Goal:** Let users see their past orders and let admins fulfill them.
**Relevant Views:**
- `Views/Orders/Track.cshtml` (Customer view)
- `Views/Admin/Orders.cshtml` (Admin list)
- `Views/Admin/Invoice.cshtml` (Admin details)
**Guidance:** Build queries to fetch orders. For the Admin area, allow admins to change the status of an order from "Processing" to "Shipped". Coordinate with Dev 3 to ensure only authenticated users can view their own order history, and only Admins can access `/Admin/Orders`.

Good luck! You sit right in the middle of Dev 1 (Products) and Dev 3 (Users). Constant communication is key!
