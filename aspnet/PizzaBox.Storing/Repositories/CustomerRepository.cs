using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
    public class CustomerRepository
    {
        private readonly PizzaBoxDBContext _dbContext;

        public CustomerRepository(PizzaBoxDBContext db)
        {
            _dbContext = db;
        }

        public CustomerModel Login(string name)
        {
            return _dbContext.Customers.SingleOrDefault(x => x.Name == name);
        }

        public bool CreateCustomer(string CustomerName)
        {
            if (Login(CustomerName) == null)
            {
                _dbContext.Customers.Add(
                    new CustomerModel() { Name = CustomerName }
                );
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CustomerModel> ReadAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public List<OrderModel> ReadOrders(string CustomerName)
        {
            var orders = _dbContext.Orders
                .Where(x => x.CustomerSubmitted.Name == CustomerName && x.Submitted)
                .Include(x => x.CustomerSubmitted)
                .Include(x => x.StoreSubmitted)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.Crust)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.Size)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.PizzaToppings)
                        .ThenInclude(x => x.Topping)
                .ToList();

            if (orders is null)
            {
                return null;
            }

            foreach (var order in orders)
            {
                foreach (var pizza in order.Pizzas)
                {
                    pizza.Toppings = new List<ToppingModel>();
                    foreach (var pizzaTopping in pizza.PizzaToppings)
                    {
                        pizza.Toppings.Add(pizzaTopping.Topping);
                    }
                }
            }

            return orders;
        }
    }
}