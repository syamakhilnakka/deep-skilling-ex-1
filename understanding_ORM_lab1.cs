using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailInventory
{
    // 1. Entity Classes
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int StockLevel { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    // 2. DbContext
    public class InventoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailInventoryDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional Fluent API
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Groceries" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", StockLevel = 10, CategoryId = 1 },
                new Product { ProductId = 2, Name = "Mobile", StockLevel = 25, CategoryId = 1 },
                new Product { ProductId = 3, Name = "Rice Bag", StockLevel = 50, CategoryId = 2 }
            );
        }
    }

    // 3. Program Entry
    class Program
    {
        static async Task Main(string[] args)
        {
            using var db = new InventoryContext();

            Console.WriteLine("Applying Migrations...");
            await db.Database.MigrateAsync();

            Console.WriteLine("=== All Products ===");
            var products = await db.Products.Include(p => p.Category).ToListAsync();
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Stock: {product.StockLevel}, Category: {product.Category.Name}");
            }

            Console.WriteLine("\nAdding a new product...");
            var newProduct = new Product
            {
                Name = "Tablet",
                StockLevel = 15,
                CategoryId = 1
            };

            db.Products.Add(newProduct);
            await db.SaveChangesAsync();

            Console.WriteLine("New product added successfully.");
        }
    }
}
