using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public class PizzaDetailsDb
    {
        private PizzaBoxDBContext _dbContext;

        public PizzaDetailsDb(PizzaBoxDBContext _db)
        {
            _dbContext = _db;
        }

        public void Pizzaingredients()
        {
            _dbContext.Crusts.Add(new CrustModel() { Name = "Thin", Price = 3 });
            _dbContext.Crusts.Add(new CrustModel() { Name = "Thick", Price = 5 });
            _dbContext.Crusts.Add(new CrustModel() { Name = "Garlic", Price = 6 });
            _dbContext.Crusts.Add(new CrustModel() { Name = "Garlic Stuffed", Price = 10 });

            _dbContext.Sizes.Add(new SizeModel() { Name = "Small", Price = 7 });
            _dbContext.Sizes.Add(new SizeModel() { Name = "Medium", Price = 9 });
            _dbContext.Sizes.Add(new SizeModel() { Name = "Large", Price = 15 });

            _dbContext.Toppings.Add(new ToppingModel() { Name = "Sauce", Price = 0.35m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Cheese", Price = 0.15m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Pepperoni", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Sausage", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Ham", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Pineapple", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Olives", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Mushrooms", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Mozzarella", Price = 0.6m });
            _dbContext.Toppings.Add(new ToppingModel() { Name = "Basil", Price = 0.20m });

            _dbContext.SaveChanges();
        }

        public void PizzaEntities()
        {
            _dbContext.Customers.Add(new CustomerModel() { Name = "Thang" });
            _dbContext.Customers.Add(new CustomerModel() { Name = "John" });

            _dbContext.Stores.Add(new StoreModel() { Name = "1" });
            _dbContext.Stores.Add(new StoreModel() { Name = "2" });

            _dbContext.SaveChanges();
        }

        public void PizzaMenu()
        {
            var cheese = new PizzaMenuModel();
            cheese.Name = "Cheese";
            cheese.Crust = _dbContext.Crusts.FirstOrDefault(x => x.Name == "Thin");
            cheese.PizzaMenuToppings = new List<PizzaMenuToppingModel>()
            {
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Sauce") },
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Cheese") }
            };
            _dbContext.PizzasMenu.Add(cheese);

            var pepperoni = new PizzaMenuModel();
            pepperoni.Name = "Pepperoni";
            pepperoni.Crust = _dbContext.Crusts.FirstOrDefault(x => x.Name == "Thin");
            pepperoni.PizzaMenuToppings = new List<PizzaMenuToppingModel>()
            {
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Sauce") },
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Cheese") },
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Pepperoni") }
            };
            _dbContext.PizzasMenu.Add(pepperoni);

            var hawaiian = new PizzaMenuModel();
            hawaiian.Name = "Hawaiian";
            hawaiian.Crust = _dbContext.Crusts.FirstOrDefault(x => x.Name == "Thin");
            hawaiian.PizzaMenuToppings = new List<PizzaMenuToppingModel>()
            {
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Sauce") },
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Cheese") },
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Ham") },
                new PizzaMenuToppingModel() { Topping = _dbContext.Toppings.FirstOrDefault(x => x.Name == "Pineapple") }
            };
            _dbContext.PizzasMenu.Add(hawaiian);

            var custom = new PizzaMenuModel();
            custom.Name = "Custom";
            _dbContext.PizzasMenu.Add(custom);

            _dbContext.SaveChanges();
        }
    }
}