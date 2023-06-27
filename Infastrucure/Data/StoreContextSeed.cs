using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infastrucure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsyn(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandData = File.ReadAllText("../Infastrucure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.Products.Any())
            {
                var ProductData = File.ReadAllText("../Infastrucure/Data/SeedData/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                context.Products.AddRange(Products);
            }

            if(!context.ProductTypes.Any())
            {
                var ProductTypeData = File.ReadAllText("../Infastrucure/Data/SeedData/types.json");
                var ProductType = JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);
                context.ProductTypes.AddRange(ProductType);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
