using System.Collections.Generic;
using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
    public class PizzaFactory : AFactory<PizzaModel>
    {
        public PizzaModel Create()
        {
            var p = new PizzaModel();

            p.Crust = new CrustModel();
            p.Size = new SizeModel();
            p.Toppings = new List<ToppingModel>();

            return p;
        }
    }
}