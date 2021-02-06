using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
    public class PizzaMenuModel : AModel
    {
        public int? CrustId { get; set; }
        public CrustModel Crust { get; set; }
        public List<ToppingModel> Toppings { get; set; }
        public List<PizzaMenuToppingModel> PizzaMenuToppings { get; set; }
        public decimal Price { get; set; }

        public decimal CalculatePrice()
        {
            return Crust.Price + Toppings.Sum(t => t.Price);
        }
    }
}