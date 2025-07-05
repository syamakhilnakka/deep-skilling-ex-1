using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailStoreApp
{
    // Models
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

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    // DbContext
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailStoreDb;Trusted_Connection=True;");
        }
    }

    // Entry Point
    class Program
    {
        static void Main()
        {
            using var db = new AppDbContext();

            Console.WriteLine("Checking & applying migrations...");
            db.Database.Migrate();

            Console.WriteLine("Seeding data if not present...");

            if (!db.Categories.Any())
            {
                var c1 = new Category { Name = "Electronics" };
                var c2 = new Category { Name = "Grocery" };

                db.Categories.AddRange(c1, c2);
                db.Products.AddRange(
                    new Product { Name = "Laptop", Price = 55000, Category = c1 },
                    new Product { Name = "Sugar", Price = 50, Category = c2 }
                );

                db.SaveChanges();
                Console.WriteLine("Seeded data successfully.");
            }

            Console.WriteLine("\n--- Products ---");
            foreach (var product in db.Products.Include(p => p.Category))
            {
                Console.WriteLine($"{product.Name} - ₹{product.Price} ({product.Category.Name})");
            }
        }
    }
}
