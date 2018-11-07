using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OShop.Logic.Shop;
using OShop.Logic.Shop.ViewModels;
using OShop.Data.Abstract;

namespace OShopen.Controllers
{
    public class StoreController : Controller
    {
        private IProductRepository repository;

        public StoreController(IProductRepository productRepository) {
            this.repository = productRepository;
        }

        

        // GET: Store
        public ActionResult Index(string Category)
        {

            //
            IEnumerable<Product> products = repository.Products
                    .Where(p => p.Category.Name == Category || Category == null);
                //CurrentCategory = Category
            //};

            //if (products != null)
            //{
                List<ProductDisplayViewModel> productsDisplay = new List<ProductDisplayViewModel>();
                foreach (var x in products)
                {
                    var productDisplay = new ProductDisplayViewModel()
                    {
                        ProductId = x.ProductId,
                        Name = x.Name,
                        ImageName = x.ImageName,
                        Price = x.Price,
                        CategoryName = x.Category.Name
                    };
                    productsDisplay.Add(productDisplay);
                }
            //return productsDisplay;
            //}

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productsDisplay,
                CurrentCategory = Category
            };
            return View(model);
 

            
        }

        
    }
}