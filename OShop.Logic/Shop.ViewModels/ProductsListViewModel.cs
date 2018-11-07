using System.Collections.Generic;

namespace OShop.Logic.Shop.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDisplayViewModel> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}