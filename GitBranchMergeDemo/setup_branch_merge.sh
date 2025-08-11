#!/bin/bash
set -e

# Variables — change these before running
REPO_DIR="GitBranchMergeDemo"
REMOTE_URL="https://github.com/YourUsername/GitBranchMergeDemo.git"  # Replace with your GitHub repo URL
USER_NAME="Your Name"
USER_EMAIL="you@example.com"

# Step 1: Create project folder and initialize Git
mkdir -p "$REPO_DIR"
cd "$REPO_DIR"
git init
git config user.name "$USER_NAME"
git config user.email "$USER_EMAIL"

# Step 2: Create initial README and commit
echo "# GitBranchMergeDemo" > README.md
echo ".DS_Store" > .gitignore
git add .
git commit -m "Initial commit with README and .gitignore"

# Step 3: Create new branch
git branch GitNewBranch
git branch -a  # List all branches
git checkout GitNewBranch  # Switch to new branch

# Step 4: Add feature file in branch
echo "This is a feature file added in GitNewBranch." > feature.txt
git add feature.txt
git commit -m "Add feature.txt in GitNewBranch"

# Step 5: Switch back to master
git checkout master

# Step 6: Show differences
git diff master GitNewBranch

# Step 7: Merge branch into master
git merge GitNewBranch --no-ff -m "Merge GitNewBranch into master"

# Step 8: Show log
git log --oneline --graph --decorate

# Step 9: Delete branch after merge
git branch -d GitNewBranch
git status

# Step 10: Push to GitHub
git branch -M main
git remote add origin "$REMOTE_URL"
git push -u origin main

echo "✅ Branch created, merged, deleted, and pushed to $REMOTE_URL"
