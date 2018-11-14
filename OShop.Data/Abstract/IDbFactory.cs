using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Data.Abstract
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
