using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Logic.Shop;

namespace OShop.Data.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
