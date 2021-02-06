using PizzaBox.Domain.Factories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factories
{
    public class StoreFactory : AFactory<StoreModel>
    {
        public StoreModel Create()
        {
            return new StoreModel();
        }
    }
}