using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
    public class SizeModel : PizzaPriceModel
    {
        public List<PizzaModel> Pizzas { get; set; }
    }
}