using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OShop.Logic.Cart;
using OShop.Logic.Shop;
using OShop.Data.Abstract;
using OShop.Logic.Order;

namespace OShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductRepository productRepository;
        private ICustomerRepository customerRepository;

        public ShoppingCartController (IProductRepository productRepo, ICustomerRepository customerRepo)
        {
            productRepository = productRepo;
            customerRepository = customerRepo;
        }


        // GET: ShoppingCart
        public ActionResult Index()
        {
            IEnumerable<CartItem> cartItems = GetCart().GetCartItems;

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                Cart = GetCart()
            };
            return View(viewModel);
        }


        public ActionResult AddToCart(int ProductId, int qty)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == ProductId);

            if (product != null)
            {
                GetCart().AddToCart(product, qty);
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult CartSummary()
        {
            return PartialView(GetCart());
        }

        private ShoppingCart GetCart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ViewResult Checkout()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout([Bind(Include = "Id,FirstName,LastName,Address,PostalCode,City,Email")] Customer customer)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart == null || cart.GetCartItems.Count() == 0)
            {
                ModelState.AddModelError("", "Du har inga varor i kundvagnen!");
            }

            if (ModelState.IsValid)
            {
                customerRepository.Add(customer);
                return View("Thanks");
            }

            return View(customer);
        }
    }
}