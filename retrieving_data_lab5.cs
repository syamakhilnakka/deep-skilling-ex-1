using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStoreApp
{
    // Model classes
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

    // Program
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("Retrieving all products...");
            var products = await context.Products.ToListAsync();
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ₹{p.Price}");

            Console.WriteLine("\nFinding product with ID = 1...");
            var product = await context.Products.FindAsync(1);
            Console.WriteLine($"Found: {product?.Name ?? "Not found"}");

            Console.WriteLine("\nFinding first product with price > ₹50000...");
            var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($"Expensive: {expensive?.Name ?? "No expensive product found"}");
        }
    }
}
