
using System.Collections.Generic;
using OShop.Logic.Shop;

namespace OShop.Data.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        bool Add(Product product);
        void Update(Product product);
    }
}
