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

            Console.WriteLine("Updating 'Laptop' price to ₹70000...");

            var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
            if (product != null)
            {
                product.Price = 70000;
                await context.SaveChangesAsync();
                Console.WriteLine("Laptop price updated.");
            }
            else
            {
                Console.WriteLine("Laptop not found.");
            }

            Console.WriteLine("\nDeleting product 'Rice Bag'...");

            var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
            if (toDelete != null)
            {
                context.Products.Remove(toDelete);
                await context.SaveChangesAsync();
                Console.WriteLine("Rice Bag deleted.");
            }
            else
            {
                Console.WriteLine("Rice Bag not found.");
            }

            // Final Product List
            Console.WriteLine("\n=== Final Product List ===");
            var products = await context.Products.ToListAsync();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price}");
            }
        }
    }
}
