#!/bin/bash
set -e

# Variables — change these before running
REPO_DIR="GitDemo"
REMOTE_URL="https://github.com/YourUsername/GitDemo.git"  # Replace with your GitHub repo URL
USER_NAME="Your Name"
USER_EMAIL="you@example.com"

# Create folder if not exists
mkdir -p "$REPO_DIR"
cd "$REPO_DIR"

# Initialize Git
git init
git config user.name "$USER_NAME"
git config user.email "$USER_EMAIL"

# Add files
git add .
git commit -m "Initial commit"

# Push to GitHub
git branch -M main
git remote add origin "$REMOTE_URL"
git push -u origin main

echo "✅ Successfully pushed to $REMOTE_URL"
