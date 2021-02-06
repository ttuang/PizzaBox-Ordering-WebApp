using PizzaBox.Domain.Models;
using PizzaBox.Domain.Factories;

namespace PizzaBox.Domain.Factories
{
    public class CustomerFactory : AFactory<CustomerModel>
    {
        public CustomerModel Create()
        {
            return new CustomerModel();
        }
    }
}