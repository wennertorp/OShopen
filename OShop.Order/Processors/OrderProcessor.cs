using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OShop.Order.Abstract;
using OShop.Data.Abstract;
using OShop.Logic.Order;
using OShop.Logic.Cart;

namespace OShop.Order.Processors
{
    public class OrderProcessor : IOrderProcessor
    {
        private ICartRepository cartRepository;
        private ICustomerRepository customerRepository;
        private IPSP paymentServiceProvider;

        private const int paymentRejected = -1;
        private const int paymentAccepted = 1;

        public OrderProcessor(ICartRepository cartRepo, ICustomerRepository customerRepo, IPSP pSP)
        {
            cartRepository = cartRepo;
            customerRepository = customerRepo;
            paymentServiceProvider = pSP;
        }

        public int ProcessOrder(ShoppingCart cart, Customer customer)
        {
            // New customer - add customer
            if (customer.CustomerId == 0)
            {
                customerRepository.Add(customer);
            }
            
            if (paymentServiceProvider.MakePayment())
            {
                customer.OrderTotal = SaveItems(cart.GetCartItems, customer.CustomerId);
                customer.OrderStatus = paymentAccepted;
                cart.RemoveAllItems();
            }
            else
            {
                customer.OrderStatus = paymentRejected;
            }

            customerRepository.Update(customer);

            return customer.OrderStatus;
        }

        private int SaveItems(IEnumerable<CartItem> cartItems, int customerId)
        {
            int total = 0;
            foreach (CartItem item in cartItems)
            {
                SaveItem(item, customerId);
                total += item.Qty * item.Product.Price;
            }
            return total;
        }

        private void SaveItem(CartItem item, int customerId)
        {
            OrderedItem orderedItem = new OrderedItem()
            {
                CustomerId = customerId,
                ProductId = item.Product.ProductId,
                Qty = item.Qty
            };
            cartRepository.Add(orderedItem);
        }


    }

    
}