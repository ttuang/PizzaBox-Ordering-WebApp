using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("/[controller]/{action=Home}")]
    public class CustomerController : Controller
    {
        private CustomerViewModel customerViewModel;

        public CustomerController(PizzaBoxDBContext _dbContext)
        {
            customerViewModel = new CustomerViewModel(_dbContext);
        }

        [HttpGet]
        public IActionResult Home()
        {
            if (TempData.Peek("CustomerLoggedIn") == null)
            {
                return View("Login", new CustomerViewModel());
            }
            return View(new CustomerViewModel() { Name = TempData.Peek("CustomerLoggedIn").ToString() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(CustomerViewModel customer)
        {
            // verify login
            if (customerViewModel.Login(customer.Name) is null)
            {
                customer.Name = null;
            }

            ModelState.Remove("CustomerSelected");
            if (ModelState.IsValid)
            {
                TempData["CustomerLoggedIn"] = customer.Name;
                TempData.Keep("CustomerLoggedIn");
                return Redirect("/Customer");
            }
            return View();
        }

        [HttpGet]
        public IActionResult NewCustomer()
        {
            return View("CreateCustomer", new CustomerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer(CustomerViewModel customer)
        {
            ModelState.Remove("CustomerSelected");
            if (ModelState.IsValid)
            {
                var NewCustomer = customerViewModel.CreateCustomer(customer.Name);

                if (NewCustomer != null)
                {
                    TempData["CustomerLoggedIn"] = customer.Name;
                    TempData.Keep("CustomerLoggedIn");
                    return Redirect("/Customer");
                }
            }
            return View(customer);
        }
        public IActionResult Logout()
        {
            TempData.Clear();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult OrderHistory()
        {
            return View(customerViewModel.OrderHistory(TempData.Peek("CustomerLoggedIn").ToString()));
        }
    }
}