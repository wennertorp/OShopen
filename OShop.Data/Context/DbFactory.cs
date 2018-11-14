using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Data.Abstract;

namespace OShop.Data.Context
{
    // Används ej   
    public class DbFactory : Disposable, IDbFactory
    {
        
        ApplicationDbContext dbContext;

        public ApplicationDbContext Init()
        {
            return dbContext ?? (dbContext = new ApplicationDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        
    }
    
}
