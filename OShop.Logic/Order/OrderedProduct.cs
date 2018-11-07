using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OShop.Logic.Shop;

namespace OShop.Logic.Order
{
    public class OrderedProduct
    {
        [Key]
        [Column(Order = 0)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CustomerOrderId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer CustomerOrder { get; set; }
    }
}