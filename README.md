# NiceShop Git Workflow Guide

Welcome to the NiceShop project! This guide is designed for beginners to Git. It will explain the fundamental concepts of version control and walk you through our project's workflow step-by-step.

## 🧠 Git Basics Explained

### What is a Commit?
A **commit** is like a snapshot or a save point of your project at a specific moment in time. When you make changes to files and "commit" them, Git takes a picture of exactly how all the files look right now. Every commit comes with a message where you describe what you changed (e.g., "Added login button"). This allows you to look back at the history of the project, see what changed and why, and even revert to older versions if something breaks.

### What is a Branch?
A **branch** is an independent line of development. Imagine your project's history as a timeline (like the trunk of a tree). Creating a branch allows you to split off from that main timeline to work on something new without affecting the original timeline. You can make commits on your branch safely; the `main` branch remains completely untouched.

### What is a Feature Branch?
A **feature branch** is a specific type of branch you create when you want to add a new feature (like a shopping cart or a new page) or fix a bug. In this project, we name these branches starting with `feature/` (e.g., `feature/shopping-cart` or `feature/xyz`). 

**Why do we use feature branches?** By using them, multiple developers can work on different features at the exact same time without their code getting mixed up, conflicting, or breaking the stable `main` branch.

---

## 🚀 The Workflow: Step-by-Step

Here is the step-by-step process you will follow from getting the code for the first time to finishing your feature.

### 1. Clone the Project
First, you need to download a copy of the project from the internet to your computer. This is called "cloning". Open your terminal or command prompt and run:
```bash
git clone <repository-url>
cd ITI_Graduation_Project
```
*(Note: Replace `<repository-url>` with the actual web link to this project's Git repository).*

### 2. Get the Latest Updates
Before starting any new work, always make sure your local `main` branch is up to date with the online version.
```bash
# Switch to the main branch
git checkout main

# Download the latest changes from the internet
git pull origin main
```

### 3. Create a Feature Branch
Now you are ready to start working! **Never work directly on the `main` branch.** Always create a new feature branch for your task.
```bash
# This creates a new branch called "feature/xyz" and switches you to it
git checkout -b feature/xyz
```
*(Replace `xyz` with a short, descriptive name for what you are working on, e.g., `feature/user-login`)*

### 4. Make Changes and Save (Commit)
Open the code in your editor, write your code, and save the files. Once you have a working piece of code, it's time to commit it.

First, tell Git which changed files you want to include in the snapshot (this is called "staging"):
```bash
# Add all changed files in the current folder
git add .
```

Next, create the commit with a descriptive message:
```bash
git commit -m "Describe what you did here"
```
*Tip: You can repeat this step (edit code -> git add -> git commit) as many times as you need while working on your feature branch.*

### 5. Push Your Branch to the Internet
When you are completely done with your feature and ready to share it with the team, you need to "push" (upload) your branch to the remote repository.
```bash
git push -u origin feature/xyz
```

### 6. Open a Pull Request (PR)
#### What is a PR?
A **Pull Request (PR)** (sometimes called a Merge Request) is a formal request you make to the project team asking them to merge your feature branch into the `main` branch. 

Think of it as submitting your homework for review. It shows everyone exactly what lines of code you added, changed, or deleted. It provides a dedicated space for your teammates to review your code, ask questions, suggest improvements, and ensure everything works perfectly before it officially becomes part of the main project.

#### How to create a PR:
1. Go to the project's repository page in your web browser (e.g., on GitHub, GitLab, or Azure DevOps).
2. You will usually see an automatic prompt at the top saying you recently pushed a branch, with a bright green button that says **"Compare & pull request"**. Click it!
3. *(If you don't see the button, go to the **Pull Requests** tab and click **"New pull request"**. Select `main` as the base branch and your `feature/xyz` branch as the compare branch.)*
4. **Add a Title and Description**: Write a clear title and describe what your feature does. Explain why you made these changes and provide any steps needed to test it.
5. **Submit**: Click the **"Create pull request"** button.
6. **Review & Merge**: Your team will now review your code. If they request changes, simply make more commits on your computer and `git push` them again—the PR will update automatically! Once approved, you or a teammate will click **"Merge pull request"**, and your code is safely combined into `main`.

After the merge is complete, your feature is live! You can go back to step 2 to pull the newly updated `main` branch and start working on your next feature.

---

## 📋 Quick Summary Workflow

For quick reference, here are the commands you will use daily:

1. **Start fresh:** 
   `git checkout main` 
   `git pull origin main`
2. **Create a branch for your task:** 
   `git checkout -b feature/xyz`
3. **Work & Stage:** (After making changes in your editor)
   `git add .`
4. **Commit your work:** 
   `git commit -m "Added xyz feature"`
5. **Upload your branch:** 
   `git push -u origin feature/xyz`
