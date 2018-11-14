using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Logic.Order;
using OShop.Logic.Cart;

namespace OShop.Order.Abstract
{
    public interface IOrderProcessor
    {
        int ProcessOrder(ShoppingCart cart, Customer customer);
    }
}
