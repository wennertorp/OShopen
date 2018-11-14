using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OShop.Data.Abstract;
using OShop.Logic.Order;

namespace OShop.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

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

        public void Update(Customer customer)
        {
            context.Customers.Attach(customer);
            var entry = context.Entry(customer);
            entry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}