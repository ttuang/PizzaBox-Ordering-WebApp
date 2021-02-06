using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel
    {
        private readonly OrderRepository repo;

        public decimal Price { get; set; }
        public DateTime DateOrdered { get; set; }
        public CustomerModel Customer { get; set; }
        public StoreModel Store { get; set; }
        public List<PizzaModel> Pizzas { get; set; }

        public List<int> PizzaIndexes { get; set; }
        public bool IndexBool { get; set; }

        public OrderViewModel() { }

        public OrderViewModel(PizzaBoxDBContext _dbContext)
        {
            repo = new OrderRepository(_dbContext);
        }

        public void CreateOrder(string CustomerName, string storeName)
        {
            repo.CreateOrder(CustomerName, storeName);
        }

        public OrderViewModel ReadOpenOrder(string CustomerName)
        {
            var order = repo.ReadOpenOrder(CustomerName);

            if (order is null)
            {
                return null;
            }

            return new OrderViewModel()
            {
                Price = order.CalculatePrice(),
                Pizzas = order.Pizzas,
                Customer = order.CustomerSubmitted,
                Store = order.StoreSubmitted
            };
        }

        public void AddPizza(PizzaViewModel pizzaViewModel, string CustomerName)
        {
            var pizza = new PizzaModel();
            pizza.Name = pizzaViewModel.PizzaName;
            pizza.Crust = pizzaViewModel.Crusts.Find(x => x.Name == pizzaViewModel.Crust);
            pizza.Size = pizzaViewModel.Sizes.Find(x => x.Name == pizzaViewModel.Size);

            pizza.Toppings = new List<ToppingModel>();
            foreach (var topping in pizzaViewModel.SelectedToppings)
            {
                pizza.Toppings.Add(pizzaViewModel.Toppings.Find(t => t.Name == topping));
            }

            repo.AddPizza(pizza, CustomerName);
        }

        public void RemovePizzas(List<int> indexes, string CustomerName)
        {
            repo.RemovePizzas(indexes, CustomerName);
        }

        public void PlaceOrder(string CustomerName)
        {
            repo.SubmitOrder(CustomerName);
        }

        public void CancelOrder(string CustomerName)
        {
            repo.CancelOrder(CustomerName);
        }
    }
}