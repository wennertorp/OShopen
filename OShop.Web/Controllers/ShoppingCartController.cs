using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OShop.Logic.Order.ViewModels;
using OShop.Logic.Shop;
using OShop.Logic.Cart;
using OShop.Logic.Order;
using OShop.Data.Abstract;
using OShop.Order.Abstract;

namespace OShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductRepository productRepository;
        private ICustomerRepository customerRepository;
        private IOrderProcessor orderProcessor;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ShoppingCartController (IProductRepository productRepo, ICustomerRepository customerRepo, IOrderProcessor processor)
        {
            productRepository = productRepo;
            customerRepository = customerRepo;
            orderProcessor = processor;
        }


        // GET: ShoppingCart
        public ActionResult Index(ShoppingCart cart, string returnUrl = "/")
        {
            var viewModel = new ShoppingCartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        // Adds to cart
        [HttpPost]
        public RedirectToRouteResult AddToCart(ShoppingCart cart, int ProductId, int qty, string returnUrl)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == ProductId);

            if (product != null)
            {
                cart.AddToCart(product, qty);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        // Returns a PartialView with total number of items and the total amount of the cart.
        public PartialViewResult CartSummary(ShoppingCart cart)
        {
            return PartialView(cart);
        }

        // Returns a PartialView with the cart's content.
        public PartialViewResult LargeCartSummary(ShoppingCart cart)
        {
            return PartialView(cart);
        }


        // GET: ShoppingCart/Checkout 
        public ActionResult Checkout(ShoppingCart cart, string returnUrl)
        {
            if (cart.IsEmpty)
            {
                return RedirectToAction("Index");
            }
            CustomerViewModel model = new CustomerViewModel();

            // If there is a Customer object in Session, send content to ViewModel
            if (Session["Customer"] != null)
            {
                Customer customer = (Customer)Session["Customer"];
                customer.ToCustomerViewModel(model);
            }
            return View(model);
        }

        // POST: ShoppingCart/Checkout
        // Saves custom details to session and redirect to Payment. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(ShoppingCart cart, CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                Customer customer = customerViewModel.ToCustomer();
                Session["customer"] = customer;

                return RedirectToAction("Payment");
            }

            return View(customerViewModel);
        }

        // GET: ShoppingCart/Payment
        // Displays cart content and customer/address details.
        public ActionResult Payment(ShoppingCart cart)
        {
            PaymentViewModel model = new PaymentViewModel()
            {
                Cart = cart,
                Customer = (Customer)Session["customer"]
            };

            return View(model);
        }
        
        // GET: ShoppingCart/OrderSubmitted
        public ActionResult OrderSubmitted(ShoppingCart cart)
        {
            Customer customer = (Customer)Session["customer"];
            if(cart.IsEmpty || customer == null)
            {
                return RedirectToAction("index");
            }

            int orderStatus = orderProcessor.ProcessOrder(cart, customer);
            
            if(orderStatus < 0)
            {
                return RedirectToAction("OrderRejected");
            }

            Session["Customer"] = null;
            return View();
        }

        public ActionResult OrderRejected()
        {
            return View();
        }

    }
}