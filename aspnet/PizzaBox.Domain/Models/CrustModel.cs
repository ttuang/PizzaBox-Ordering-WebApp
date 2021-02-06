using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CrustModel : PizzaPriceModel
    {
        public List<PizzaMenuModel> MenuPizzas { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
    }
}