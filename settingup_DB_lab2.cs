using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailStoreApp
{
    // 1. Models
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    // 2. DbContext
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your own SQL Server connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailStoreDb;Trusted_Connection=True;");
        }
    }

    // 3. Program Entry
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();

            Console.WriteLine("Applying Migrations...");
            db.Database.Migrate();

            // Seed Data
            if (!db.Categories.Any())
            {
                var electronics = new Category { Name = "Electronics" };
                var grocery = new Category { Name = "Groceries" };

                db.Categories.AddRange(electronics, grocery);

                db.Products.AddRange(
                    new Product { Name = "Phone", Price = 699.99m, Category = electronics },
                    new Product { Name = "TV", Price = 1199.50m, Category = electronics },
                    new Product { Name = "Sugar", Price = 45.25m, Category = grocery }
                );

                db.SaveChanges();
                Console.WriteLine("Sample data added.");
            }

            // Read Data
            var products = db.Products.Include(p => p.Category).ToList();
            Console.WriteLine("\n=== Product List ===");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price} ({p.Category.Name})");
            }
        }
    }
}
