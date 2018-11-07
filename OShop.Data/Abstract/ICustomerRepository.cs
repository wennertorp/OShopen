using System.Collections.Generic;
using OShop.Logic.Order;

namespace OShop.Data.Abstract
{
    public interface ICustomerRepository
    {
        bool Add(Customer customer);
        IEnumerable<Customer> Customers { get; }
    }
}
