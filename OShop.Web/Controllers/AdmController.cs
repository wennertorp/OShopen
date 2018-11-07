using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using OShop.Data.Abstract;
using OShop.Logic.Shop;

namespace OShop.Web.Controllers
{
    public class AdmController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public AdmController(IProductRepository repository, ICategoryRepository catRepository)
        {
            productRepository = repository;
            categoryRepository = catRepository;
        }

        
        public ActionResult Index()
        {
            return View(productRepository.Products);
        }

        

        // GET: Adm/Edit
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
    }
}