using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("/[controller]/[action]")]
    public class OrderController : Controller
    {
        private OrderViewModel orderViewModel;
        private PizzaViewModel pizzaViewModel;
        private StoreViewModel storeViewModel;

        public OrderController(PizzaBoxDBContext _dbContext)
        {
            // _db = dbContext;
            orderViewModel = new OrderViewModel(_dbContext);
            pizzaViewModel = new PizzaViewModel(_dbContext);
            storeViewModel = new StoreViewModel(_dbContext);
        }

        public IActionResult Home()
        {
            // customer is not logged in
            if (TempData.Peek("CustomerLoggedIn") is null)
            {
                return Redirect("/Customer");
            }

            var Customercart = orderViewModel.ReadOpenOrder(TempData.Peek("CustomerLoggedIn").ToString());

            //create new order
            if (Customercart is null)
            {
                return View("SelectStore", storeViewModel);
            }

            return View(Customercart); // return Customer cart
        }

        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(StoreViewModel store)
        {
            ModelState.Remove("Name"); //
            if (ModelState.IsValid)
            {
                orderViewModel.CreateOrder(TempData.Peek("CustomerLoggedIn").ToString(), store.StoreSelected);
                return View("AddPizza", pizzaViewModel);
            }

            return View("SelectStore", store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPizza(PizzaViewModel pizza)
        {
            // Pizza Choice (types)
            pizza.Presets = pizzaViewModel.Presets;
            pizza.Sizes = pizzaViewModel.Sizes;
            pizza.Crusts = pizzaViewModel.Crusts;
            pizza.Toppings = pizzaViewModel.Toppings;

            // remove
            ModelState.Remove("Crust");
            ModelState.Remove("SelectedToppings");
            if (ModelState.IsValid)
            {
                if (pizza.PizzaName == "Custom") // This will create Crust and Toppings, if custom
                {
                    return View("CustomizePizza", pizza);
                }

                // option for preset
                pizza.Crust = pizzaViewModel.Presets.Find(x => x.Name == pizza.PizzaName).Crust.Name;
                pizza.SelectedToppings = pizzaViewModel.Presets.Find(x => x.Name == pizza.PizzaName).Toppings.Select(x => x.Name).ToList();

                orderViewModel.AddPizza(pizza, TempData.Peek("CustomerLoggedIn").ToString());
                return Redirect("/Order/Home");
            }
            return View("AddPizza", pizza); // form was not filled out correctly
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomizePizza(PizzaViewModel pizza)
        {
            // add back in pizza options
            pizza.Presets = pizzaViewModel.Presets;
            pizza.Sizes = pizzaViewModel.Sizes;
            pizza.Crusts = pizzaViewModel.Crusts;
            pizza.Toppings = pizzaViewModel.Toppings;

            if (ModelState.IsValid)
            {
                orderViewModel.AddPizza(pizza, TempData.Peek("CustomerLoggedIn").ToString());
                return Redirect("/Order/Home");
            }
            return View(pizza);
        }

        [HttpGet]
        // [ValidateAntiForgeryToken]
        public IActionResult AddPizza()
        {
            return View(pizzaViewModel);
        }

        [HttpGet]
        // [ValidateAntiForgeryToken]
        public IActionResult RemovePizzas()
        {
            var Customercart = orderViewModel.ReadOpenOrder(TempData.Peek("CustomerLoggedIn").ToString());
            return View(Customercart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePizzas(OrderViewModel Customercart)
        {
            if (Customercart.PizzaIndexes is { })
            {
                orderViewModel.RemovePizzas(Customercart.PizzaIndexes, TempData.Peek("CustomerLoggedIn").ToString());
            }
            return Redirect("/Order/Home");
        }

        [HttpGet]
        // [ValidateAntiForgeryToken]
        public IActionResult CancelOrder()
        {
            orderViewModel.CancelOrder(TempData.Peek("CustomerLoggedIn").ToString());
            return Redirect("/Customer");
        }

        [HttpGet]
        // [ValidateAntiForgeryToken]
        public IActionResult PlaceOrder()
        {
            orderViewModel.PlaceOrder(TempData.Peek("CustomerLoggedIn").ToString());
            return Redirect("/");
        }
    }
}