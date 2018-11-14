using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Logic.Order;

namespace OShop.Data.Abstract
{
    public interface ICartRepository
    {
        bool Add(OrderedItem item);
        IEnumerable<OrderedItem> Items { get; }
    }
}
