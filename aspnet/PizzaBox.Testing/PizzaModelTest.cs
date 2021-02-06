using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class PizzaModelTest
    {
        [Fact]
        public void Testing_PriceCalculation()
        {
            var sut = new PizzaModel();
            sut.Crust = new CrustModel() { Price = 5 };
            sut.Size = new SizeModel() { Price = 7.5m };
            sut.Toppings = new List<ToppingModel>()
            {
                new ToppingModel() { Price = 0.25m },
                new ToppingModel() { Price = 0.5m }
            };

            decimal price = 13.25m;

            Assert.True(sut.CalculatePrice() == price);
        }
    }
}