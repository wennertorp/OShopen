﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OShop.Data.Abstract;


namespace OShop.Web.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        // Returns a PartialView with a list of all categories [string] with at least one product.
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
           
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category.Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}