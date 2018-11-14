using System;
using System.Data.Entity;
using OShop.Logic.Shop;
using OShop.Logic.Cart;
using OShop.Logic.Order;


namespace OShop.Data.Abstract
{
    public interface IContext : IDisposable
    {
        DbSet<Category> Categories { get; }
        DbSet<Product> Products { get; }
        DbSet<Customer> Customers { get; }
        DbSet<OrderedItem> OrderedItems { get; }

        DbContext Context { get; }
    }
}
