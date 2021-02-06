using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Repositories
{
    public class OrderRepository
    {
        private readonly PizzaBoxDBContext _dbContext;

        public OrderRepository(PizzaBoxDBContext db)
        {
            _dbContext = db;
        }

        public void CreateOrder(string CustomerName, string storeName)
        {
            var order = new OrderModel();
            order.CustomerSubmitted = _dbContext.Customers.SingleOrDefault(x => x.Name == CustomerName);
            order.StoreSubmitted = _dbContext.Stores.SingleOrDefault(x => x.Name == storeName);
            order.Price = 0;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public OrderModel ReadOpenOrder(string name)
        {
            var order = _dbContext.Orders
                .Include(x => x.CustomerSubmitted)
                .Include(x => x.StoreSubmitted)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.Crust)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.Size)
                .Include(x => x.Pizzas)
                    .ThenInclude(x => x.PizzaToppings)
                        .ThenInclude(x => x.Topping)
                .SingleOrDefault(x => x.CustomerSubmitted.Name == name && x.Submitted == false);

            if (order is null)
            {
                return null;
            }

            foreach (var pizza in order.Pizzas)
            {
                pizza.Toppings = new List<ToppingModel>();
                foreach (var pizzaTopping in pizza.PizzaToppings)
                {
                    pizza.Toppings.Add(pizzaTopping.Topping);
                }
            }

            return order;
        }

        public void AddPizza(PizzaModel pizza, string CustomerName)
        {
            var order = ReadOpenOrder(CustomerName);

            pizza.PizzaToppings = new List<PizzaToppingModel>();
            foreach (var topping in pizza.Toppings)
            {
                pizza.PizzaToppings.Add(new PizzaToppingModel()
                {
                    Topping = topping
                });
            }

            pizza.Price = pizza.CalculatePrice();

            order.Pizzas.Add(pizza);

            order.Price = order.CalculatePrice();

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void RemovePizzas(List<int> indexes, string CustomerName)
        {
            var order = ReadOpenOrder(CustomerName);

            foreach (var i in indexes)
            {
                // _db.Pizzas.Remove(order.Pizzas[i]);
                var id = order.Pizzas[i].Id;
                _dbContext.PizzaToppings.RemoveRange(
                    _dbContext.PizzaToppings.Where(x => x.PizzaId == id)
                );
                _dbContext.Pizzas.Remove(_dbContext.Pizzas.SingleOrDefault(x => x.Id == id));
            }

            _dbContext.SaveChanges();
        }

        public void SubmitOrder(string CustomerName)
        {
            var order = ReadOpenOrder(CustomerName);
            order.PurchaseDate = DateTime.UtcNow;
            order.Submitted = true;
            order.Price = order.CalculatePrice();

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

        public void CancelOrder(string CustomerName)
        {
            var order = ReadOpenOrder(CustomerName);

            foreach (var id in order.Pizzas.Select(x => x.Id))
            {
                _dbContext.PizzaToppings.RemoveRange(
                    _dbContext.PizzaToppings.Where(x => x.PizzaId == id)
                );
                _dbContext.Pizzas.Remove(
                    _dbContext.Pizzas.SingleOrDefault(x => x.Id == id)
                );
            }

            _dbContext.Orders.Remove(
                _dbContext.Orders.SingleOrDefault(x => x.CustomerSubmitted.Name == CustomerName && !x.Submitted)
            );

            _dbContext.SaveChanges();
        }

        public List<CrustModel> ReadCrusts()
        {
            return _dbContext.Crusts.ToList();
        }

        public List<SizeModel> ReadSizes()
        {
            return _dbContext.Sizes.ToList();
        }

        public List<ToppingModel> ReadToppings()
        {
            return _dbContext.Toppings.ToList();
        }

        public List<PizzaMenuModel> ReadPrests()
        {
            return _dbContext.PizzasMenu
                .Include(x => x.Crust)
                .Include(x => x.PizzaMenuToppings)
                    .ThenInclude(x => x.Topping)
                .ToList();
        }

        public List<StoreModel> ReadAllStores()
        {
            return _dbContext.Stores.ToList();
        }
    }
}