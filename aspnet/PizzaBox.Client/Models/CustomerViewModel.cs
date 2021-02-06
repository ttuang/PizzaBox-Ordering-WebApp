using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        private readonly CustomerRepository CustomerRepo;

        public List<OrderModel> Orders { get; set; }
        public List<CustomerModel> CustomerList { get; set; }

        [Required(ErrorMessage = "Login Again")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must select a store")]
        public string CustomerSelected { get; set; }

        public CustomerViewModel() { }

        public CustomerViewModel(PizzaBoxDBContext dbContext)
        {
            CustomerRepo = new CustomerRepository(dbContext);

            CustomerList = CustomerRepo.ReadAllCustomers();
        }

        public CustomerModel Login(string name)
        {
            return CustomerRepo.Login(name);
        }

        public CustomerModel CreateCustomer(string name)
        {
            if (CustomerRepo.CreateCustomer(name))
            {
                return Login(name);
            }
            return null;
        }

        public CustomerViewModel OrderHistory(string CustomerName)
        {
            var customerViewModel = new CustomerViewModel();
            customerViewModel.Orders = CustomerRepo.ReadOrders(CustomerName);
            return customerViewModel;
        }
    }
}