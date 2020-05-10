using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Core.Entities;
using System;
using Microsoft.Extensions.Logging;

namespace Shop.Infrastructure.Data
{
    public class ShopContextFeed
    {
        public static async Task SeedAsync(ShopContext shopContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!shopContext.Categories.Any())
                {
                    var categoryData = File.ReadAllText("../Shop.Infrastructure/Data/SeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    var productData = File.ReadAllText("../Shop.Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var category in categories)
                    {
                        await shopContext.Categories.AddAsync(category);
                    }
                    await shopContext.SaveChangesAsync();
                }

                if (!shopContext.Products.Any())
                {
                    var productData = File.ReadAllText("../GetProductsshop.Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var product in products)
                    {
                        await shopContext.Products.AddAsync(product);
                    }
                    await shopContext.SaveChangesAsync();
                }                
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<ShopContextFeed>();
                logger.LogError(exception, "An error occurred while seeding data.");
            }
        }
    }
}
