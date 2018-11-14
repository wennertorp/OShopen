using System.ComponentModel.DataAnnotations;
using OShop.Logic.Shop;

namespace OShop.Logic.Cart
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public virtual Product Product { get; set; }

    }
}