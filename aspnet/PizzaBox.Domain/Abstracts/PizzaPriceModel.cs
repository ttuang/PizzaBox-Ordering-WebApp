using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class PizzaPriceModel : AModel
    {
        public decimal Price { get; set; }
    }
}