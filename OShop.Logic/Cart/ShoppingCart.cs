using System.Collections.Generic;
using System.Linq;
using OShop.Logic.Shop;

namespace OShop.Logic.Cart
{
    public class ShoppingCart
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public void AddToCart(Product product, int qty)
        {
            CartItem item = cartItems
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            // Product is NOT in cart, add new.
            if (item == null)
            {
                cartItems.Add(new CartItem { Product = product, Qty = qty });
            }

            // Product is already in cart, increase qty.
            else
            {
                item.Qty += qty;
            }

        }


        public void RemoveFromCart(Product product)
        {
            cartItems.RemoveAll(p => p.ProductId == product.ProductId);
        }

        public void RemoveAllItems()
        {
            cartItems.Clear();
        }


        public int GetCartTotal()
        {
            return cartItems.Sum(p => p.Product.Price * p.Qty);
        }

        public IEnumerable<CartItem> GetCartItems
        {
            get {  return cartItems; }
        }

        public bool IsEmpty
        {
            get { return (cartItems.Count == 0); }
        }
    }
}