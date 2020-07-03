using PBR.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext dataContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            if (retry != null)
            {
                var retryForAvailability = retry.Value;

                try
                {
                    // TODO: Only run this if using a real database
                    // DataContext.Database.Migrate();
                    // DataContext.Database.EnsureCreated();

                    if (!dataContext.Categories.Any())
                    {
                        await dataContext.Categories.AddRangeAsync(GetPreconfiguredCategories());
                        await dataContext.SaveChangesAsync();
                    }

                    if (!dataContext.Products.Any())
                    {
                        await dataContext.Products.AddRangeAsync(GetPreconfiguredProducts());
                        await dataContext.SaveChangesAsync();
                    }
                }
                catch (Exception exception)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        var log = loggerFactory.CreateLogger<DataContextSeed>();
                        log.LogError(exception.Message);
                        await SeedAsync(dataContext, loggerFactory, retryForAvailability);
                    }
                    throw;
                }
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category() { CategoryName = "Phone"},
                new Category() { CategoryName = "TV"}
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product() { ProductName = "IPhone", CategoryId = 1 , UnitPrice = 19.5M , UnitsInStock = 10, QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false },
                new Product() { ProductName = "Samsung", CategoryId = 1 , UnitPrice = 33.5M , UnitsInStock = 10, QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false },
                new Product() { ProductName = "LG TV", CategoryId = 2 , UnitPrice = 33.5M , UnitsInStock = 10, QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false }
            };
        }
    }
}
