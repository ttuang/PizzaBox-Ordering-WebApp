using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class StoreModel : AModel
    {
        public List<OrderModel> Orders { get; set; }
    }
}