using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("/[controller]/{action=Home}")]
    public class StoreController : Controller
    {
        private StoreViewModel storeViewModel;
        private CustomerViewModel customerViewModel;

        public StoreController(PizzaBoxDBContext  _dbContext)
        {
            storeViewModel = new StoreViewModel(_dbContext);
            customerViewModel = new CustomerViewModel(_dbContext);
        }

        [HttpGet]
        public IActionResult Home()
        {
            if (TempData.Peek("StoreLoggedIn") == null)
            {
                return View("Login", new StoreViewModel());
            }
            return View(new StoreViewModel() { Name = TempData.Peek("StoreLoggedIn").ToString() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(StoreViewModel store)
        {
            // super bodge job to verify login
            if (storeViewModel.Login(store.Name) is null)
            {
                store.Name = null;
            }

            ModelState.Remove("StoreSelected");
            if (ModelState.IsValid)
            {
                TempData["StoreLoggedIn"] = store.Name;
                TempData.Keep("StoreLoggedIn");
                return Redirect("/Store");
            }
            return View();
        }

        [HttpGet]
        public IActionResult NewStore()
        {
            return View("CreateStore", new StoreViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStore(StoreViewModel store)
        {
            ModelState.Remove("StoreSelected");
            if (ModelState.IsValid)
            {
                var newStore = storeViewModel.CreateStore(store.Name);

                if (newStore != null)
                {
                    TempData["StoreLoggedIn"] = store.Name;
                    TempData.Keep("StoreLoggedIn");
                    return Redirect("/Store");
                }
            }
            return View(store);
        }

        public IActionResult Logout()
        {
            TempData.Clear();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult OrderHistory()
        {
            return View(storeViewModel.OrderHistory(TempData.Peek("StoreLoggedIn").ToString()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderHistory(CustomerViewModel customer)
        {
            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                return View(storeViewModel.OrderHistory(TempData.Peek("StoreLoggedIn").ToString(), customer.CustomerSelected));
            }
            return View("CustomerSelector", customerViewModel);
        }

        [HttpGet]
        public IActionResult OrderHistoryByCustomer()
        {
            return View("CustomerSelector", customerViewModel);
        }
    }
}