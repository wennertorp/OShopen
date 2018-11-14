using OShop.Logic.Shop.ViewModels;

namespace OShop.Logic.Shop
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageName { get; set; }
        public virtual Category Category { get; set; }


        public ProductDisplayViewModel ToProductDisplayViewModel()
        {
            ProductDisplayViewModel model = new ProductDisplayViewModel
            {
                ProductId = ProductId,
                Name = Name,
                ImageName = ImageName,
                Price = Price,
                CategoryName = Category.Name
            };

            return model;
        }
    }
}