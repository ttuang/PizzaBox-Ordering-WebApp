using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
    public class ToppingModel : PizzaPriceModel
    {
        public List<PizzaToppingModel> PizzaToppings { get; set; }
        public List<PizzaMenuToppingModel> PizzaMenuToppings { get; set; }
    }
}