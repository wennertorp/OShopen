using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OShop.Logic.Shop;

namespace OShop.Logic.Order
{
    public class OrderedItem
    {
        [Key]
        [Column(Order = 0)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CustomerId { get; set; }

        public int Qty { get; set; }

        public virtual Product Product { get; set; }
    }
}