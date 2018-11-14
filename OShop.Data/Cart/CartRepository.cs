using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Data.Abstract;
using OShop.Logic.Order;

namespace OShop.Data
{
    public class CartRepository : ICartRepository
    {
        private ApplicationDbContext context;

        public CartRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public bool Add(OrderedItem item)
        {
            if (item != null)
            {
                context.OrderedItems.Add(item);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<OrderedItem> Items
        {
            get
            {
                List<OrderedItem> items = new List<OrderedItem>();
                items = context.OrderedItems.AsNoTracking().ToList();
                return items;

            }
        }
    }
}
