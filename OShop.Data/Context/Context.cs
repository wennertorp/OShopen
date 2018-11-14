using System.Data.Entity;
using OShop.Logic.Shop;
using OShop.Logic.Cart;
using OShop.Logic.Order;
using OShop.Data.Abstract;

namespace OShop.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected readonly DbContext context;

        public ApplicationDbContext() : base("ApplicationDbContext")
        {
          //  context = dbContext;
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderedItem> OrderedItems { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
