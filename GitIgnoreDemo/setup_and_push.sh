#!/bin/bash
set -e

# Variables — change these before running
REPO_DIR="GitIgnoreDemo"
REMOTE_URL="https://github.com/YourUsername/GitIgnoreDemo.git"  # Replace with your GitHub repo URL
USER_NAME="Your Name"
USER_EMAIL="you@example.com"

# Create folder if not exists
mkdir -p "$REPO_DIR"
cd "$REPO_DIR"

# Create example files and folders
echo "# GitIgnoreDemo" > README.md
echo "This is a log file that should be ignored by Git." > notes.log
mkdir -p logs
echo "This is a log file inside the logs folder that should also be ignored by Git." > logs/error.log

# Create .gitignore
cat > .gitignore <<EOF
# Ignore all .log files
*.log

# Ignore logs folder
logs/
EOF

# Initialize Git
git init
git config user.name "$USER_NAME"
git config user.email "$USER_EMAIL"

# Add only files not ignored
git add .
git commit -m "Initial commit (with .gitignore to exclude .log files and logs folder)"

# Push to GitHub
git branch -M main
git remote add origin "$REMOTE_URL"
git push -u origin main

echo "✅ Successfully pushed to $REMOTE_URL"
