using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Data.Abstract;
using OShop.Logic.Shop;

namespace OShop.Data
{
    public class CategoryRepository : ICategoryRepository
    {

        private ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                List<Category> categories = new List<Category>();
                categories = context.Categories.AsNoTracking().ToList();

                return categories;

            }
        }


    }
}
