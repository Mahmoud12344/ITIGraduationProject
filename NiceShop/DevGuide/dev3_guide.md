# Developer 3: Identity, Admin & AI Guide

Welcome to the team! You own the foundational plumbing: Security, User Authentication, the overall layout routing, and the advanced AI features.

## Git & GitHub Workflow for Beginners
We are keeping things simple using a Two-Branch Workflow (`main` and `feature` branches). **Never write code directly on the `main` branch.**

1. **Start Fresh:** Always get the latest code before starting a task.
   ```bash
   git checkout main
   git pull origin main
   ```
2. **Create Your Feature Branch:** Name it after your task (e.g., DEV3-01).
   ```bash
   git checkout -b DEV3-01-identity
   ```
3. **Write Code & Commit:** Save your work as you go.
   ```bash
   git add .
   git commit -m "Setup ASP.NET Identity"
   ```
4. **Push to GitHub:**
   ```bash
   git push -u origin DEV3-01-identity
   ```
5. **Create a Pull Request (PR):** Go to GitHub, click "Compare & pull request", and merge your feature branch into `main`. Once merged, go back to step 1 for your next task!

---

## Your Tasks & Frontend Integration Guide

Your job is to secure the application, manage the overall layout templates, and inject smart functionality. 

### 1. Identity Setup (DEV3-01)
**Goal:** Setup ASP.NET Core Identity.
**Guidance:** Install the ASP.NET Core Identity NuGet packages. Create an `ApplicationUser` class that inherits from `IdentityUser`. Configure the Identity middleware in `Program.cs`. Seed two default Roles into the database: "Admin" and "Customer". 

### 2. Base Layout & Seed (DEV3-02)
**Goal:** Control the global UI state based on user login.
**Relevant Views:**
- `Views/Shared/_Layout.cshtml`
- `Views/Shared/Partials/_Header.cshtml`
**Guidance:** In `_Header.cshtml`, you will see static HTML for "Login" and "Admin" buttons. You need to wrap these in Razor `if` statements:
- Use `@if(User.Identity.IsAuthenticated)` to show "Logout" instead of "Login".
- Use `@if(User.IsInRole("Admin"))` to only show the Admin dashboard button to administrators.

### 3. Auth Flows (DEV3-03)
**Goal:** Let users create accounts and sign in.
**Relevant Views:**
- `Views/Auth/Index.cshtml` (Contains both Login and Register forms)
**Guidance:** The frontend currently has a single Auth page with tabs for Login and Register. You need to write the `AuthController` with `[HttpPost]` endpoints for `/Auth/Login` and `/Auth/Register`. Use Identity's `SignInManager` and `UserManager` to process these forms.

### 4. Admin & Coupons (DEV3-04)
**Goal:** Secure the admin area and implement Coupons.
**Relevant Views:**
- `Views/Shared/_AdminLayout.cshtml`
- `Views/Admin/Dashboard.cshtml`
- `Views/Admin/CategoriesCoupons.cshtml` (Coupons tab)
**Guidance:** Apply the `[Authorize(Roles = "Admin")]` attribute to the entire `AdminController`. Build the CRUD functionality for the `Coupon` entity so Admins can create discount codes. Dev 2 will need to query your Coupons table during checkout!

### 5. AI Recommendations (DEV3-05)
**Goal:** Add a smart recommendation engine.
**Guidance:** Once Dev 1 has the `Products` table populated, build an `AIController` or an `AIService`. This could use an external LLM API (like OpenAI) or a simple internal algorithm to recommend products based on a user's past orders or current cart. You can expose this as a JSON API that the frontend can fetch.

### 6. Reviews Moderation & Security (DEV3-06)
**Goal:** Secure the site and moderate content.
**Relevant Views:**
- `Views/Admin/Reviews.cshtml`
**Guidance:** Build the Admin panel to view, approve, or delete product reviews left by customers. Ensure all your controllers have proper `[Authorize]` attributes and protect against CSRF attacks using `[ValidateAntiForgeryToken]`.

Good luck! You are the security gatekeeper. Ensure Dev 1 and Dev 2 coordinate with you whenever they need to check if a user is logged in.
