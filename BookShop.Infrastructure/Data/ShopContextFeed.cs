using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Entities;
using System;
using Microsoft.Extensions.Logging;

namespace BookShop.Infrastructure.Data
{
    public class ShopContextFeed
    {
        public static async Task SeedAsync(ShopContext shopContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!shopContext.Genres.Any())
                {
                    var genreData = File.ReadAllText("../BookShop.Infrastructure/Data/SeedData/genres.json");
                    var genres = JsonSerializer.Deserialize<List<Genre>>(genreData);

                    var bookData = File.ReadAllText("../Bookshop.Infrastructure/Data/SeedData/books.json");
                    var books = JsonSerializer.Deserialize<List<Book>>(bookData);

                    foreach (var genre in genres)
                    {
                        await shopContext.Genres.AddAsync(genre);
                    }
                    await shopContext.SaveChangesAsync();
                }

                if (!shopContext.Books.Any())
                {
                    var bookData = File.ReadAllText("../Bookshop.Infrastructure/Data/SeedData/books.json");
                    var books = JsonSerializer.Deserialize<List<Book>>(bookData);

                    foreach (var book in books)
                    {
                        await shopContext.Books.AddAsync(book);
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
