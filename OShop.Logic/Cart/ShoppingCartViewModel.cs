using System.Collections.Generic;

namespace OShop.Logic.Cart
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public ShoppingCart Cart { get; set; }
    }
}