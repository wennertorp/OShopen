using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using OShop.Data.Abstract;
using OShop.Logic.Shop;
using OShop.Logic.Shop.ViewModels;
using OShop.Logic.Order;
using OShop.Logic.Order.ViewModels;


namespace OShop.Web.Controllers
{
    public class AdmController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICartRepository cartRepository;

        public AdmController(IProductRepository repository, ICategoryRepository catRepository, ICustomerRepository custRepository, ICartRepository cartRepo)
        {
            productRepository = repository;
            categoryRepository = catRepository;
            customerRepository = custRepository;
            cartRepository = cartRepo;
        }

        
        public ActionResult Index()
        {
            return View(productRepository.Products);
        }

        

        // GET: Adm/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = productRepository.Products
                .FirstOrDefault(p => p.ProductId == id);
            if(product == null)
            {
                return HttpNotFound();
            }
            List<Category> categories = categoryRepository.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Adm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CategoryId,Name,Price,ImageName")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Update(product);
                return RedirectToAction("Index");
            }

            List<Category> categories = categoryRepository.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Adm/Create
        public ActionResult Create()
        {
            List<Category> categories = categoryRepository.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        // POST: Adm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,Name,Price,ImageName")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(product);
                return RedirectToAction("Index");
            }

            List<Category> categories = categoryRepository.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Adm/Orders
        public ActionResult Orders()
        {
            List<Category> categories = categoryRepository.Categories.ToList(); 
            IEnumerable<Customer> customers = customerRepository.Customers;
            List<OrderSummaryViewModel> orderSummaries = new List<OrderSummaryViewModel>();
            
            foreach(Customer customer in customers)
            {
                IEnumerable<OrderedItem> products = cartRepository.Items.Where(p => p.CustomerId == customer.CustomerId).ToList();

                OrderSummaryViewModel model = new OrderSummaryViewModel()
                {
                    Customer = customer,
                    OrderedItems = products
                };
                orderSummaries.Add(model);
            }

            return View(orderSummaries);
        }
    }


}