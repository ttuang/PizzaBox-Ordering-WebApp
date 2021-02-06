using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class PizzaMenuModelTest
    {
        [Fact]
        public void Testing_PriceCalculation()
        {
            var sut = new PizzaMenuModel();
            sut.Crust = new CrustModel() { Price = 5 };
            sut.Toppings = new List<ToppingModel>()
            {
                new ToppingModel() { Price = 0.25m },
                new ToppingModel() { Price = 0.5m }
            };

            decimal price = 5.75m;

            Assert.True(sut.CalculatePrice() == price);
        }
    }
}