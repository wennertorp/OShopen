using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OShop.Logic.Cart;

namespace OShop.Logic.Order.ViewModels
{
    public class OrderSummaryViewModel
    {
        public Customer Customer;
        public IEnumerable<OrderedItem> OrderedItems;
    }
}