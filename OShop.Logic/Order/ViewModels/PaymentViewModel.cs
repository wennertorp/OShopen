using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OShop.Logic.Cart;

namespace OShop.Logic.Order.ViewModels
{
    public class PaymentViewModel
    {
        public ShoppingCart Cart { get; set; }
        public Customer Customer { get; set; }
    }
}