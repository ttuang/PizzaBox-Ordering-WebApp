using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Models
{
    public class PizzaMenuToppingModel
    {
        public int Id { get; set; }
        public int PizzaMenuId { get; set; }
        public int ToppingId { get; set; }
        public PizzaMenuModel PizzaMenu { get; set; }
        public ToppingModel Topping { get; set; }
    }
}