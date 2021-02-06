using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerSubmittedId { get; set; }
        public int StoreSubmittedId { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Submitted { get; set; }

        public List<PizzaModel> Pizzas { get; set; }
        public CustomerModel CustomerSubmitted { get; set; }
        public StoreModel StoreSubmitted { get; set; }

        public OrderModel()
        {
            Pizzas = new List<PizzaModel>();
        }

        public decimal CalculatePrice()
        {
            return Pizzas.Sum(p => p.CalculatePrice());
        }
    }
}