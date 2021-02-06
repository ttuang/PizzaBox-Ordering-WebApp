using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
    public class OrderFactory : AFactory<OrderModel>
    {
        public OrderModel Create()
        {
            return new OrderModel();
        }
    }
}