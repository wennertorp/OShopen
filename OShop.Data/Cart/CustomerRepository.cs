using System.Collections.Generic;
using System.Linq;
using OShop.Data.Abstract;
using OShop.Logic.Order;

namespace OShop.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public bool Add(Customer customer)
        {
            if(customer != null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> Customers
        {
            get
            {
                List<Customer> customers = new List<Customer>();
                customers = context.Customers.AsNoTracking().ToList();
                return customers;

            }
        }
    }
}