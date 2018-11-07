using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OShop.Data.Abstract;
using OShop.Logic.Shop;

namespace OShop.Data
{
    public class ProductsRepository : IProductRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Product> Products {
            get {
                List<Product> products = new List<Product>();
                products = context.Products.AsNoTracking()
                    .Include(p => p.Category)
                    .ToList();
                return products;
                
            }
        }

        public bool Add(Product product)
        {
            if (product != null)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(Product product)
        {
            
            context.Products.Attach(product);
            var entry = context.Entry(product);
            entry.State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}