using System.Collections.Generic;
using OShop.Logic.Shop;

namespace OShop.Data
{
    public class OShopDBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Kompasser", CategoryId=1 },
                new Category { Name = "Skor", CategoryId=2 },
                new Category { Name = "Lampor", CategoryId=3 },
                new Category { Name = "Kläder", CategoryId=4 },
                new Category { Name = "Tillbehör", CategoryId=5 }
            };
            categories.ForEach(s => context.Categories.Add(s));

            var products = new List<Product>
            {
                new Product {
                    Name = "Mila Vega II",
                    Price = 4495,
                    CategoryId = 3,
                    ImageName = "MilaVegaII.jpg"
                },
                new Product {
                    CategoryId = 1,
                    Name = "Silva Race Jet",
                    Price = 795,
                    ImageName = "SilvaRaceJet.jpg"
                },
                new Product {
                    CategoryId = 2,
                    Name = "Inov-8 X-Talon 212",
                    Price = 1495,
                    ImageName = "Inov8x-talon212.jpg"
                },
                new Product {
                    CategoryId = 2,
                    Name = "VJ Bold",
                    Price = 1595,
                    ImageName = "VJBold.jpg"
                },
                new Product {
                    CategoryId = 2,
                    Name = "Icebug Spirit",
                    Price = 1595,
                    ImageName = "IcebugSpirit.jpg"
                }
            };
            products.ForEach(s => context.Products.Add(s));

            
            base.Seed(context);
        }
    }
}