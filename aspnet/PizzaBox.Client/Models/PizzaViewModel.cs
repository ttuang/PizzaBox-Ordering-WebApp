using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
    public class PizzaViewModel
    {
        private readonly OrderRepository orderRepo;

        // out to the client
        public List<PizzaMenuModel> Presets { get; set; }
        public List<CrustModel> Crusts { get; set; }
        public List<SizeModel> Sizes { get; set; }
        public List<ToppingModel> Toppings { get; set; }
        public decimal Price { get; set; }


        // in from the client

        [Required(ErrorMessage = "Must select a pizza base")]
        public string PizzaName { get; set; }

        [Required(ErrorMessage = "Must select a crust")]
        public string Crust { get; set; }

        [Required(ErrorMessage = "Must select a size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Must select between 2 and 5 toppings")]
        [MinLength(2, ErrorMessage = "Must select between 2 and 5 toppings")]
        [MaxLength(5, ErrorMessage = "Must select between 2 and 5 toppings")]
        public List<string> SelectedToppings { get; set; }
        public bool SelectedTopping { get; set; }

        public PizzaViewModel() { }

        public PizzaViewModel(PizzaBoxDBContext _dbContext)
        {
            orderRepo = new OrderRepository(_dbContext);

            Crusts = orderRepo.ReadCrusts();
            Sizes = orderRepo.ReadSizes();
            Toppings = orderRepo.ReadToppings();
            Presets = orderRepo.ReadPrests();

            foreach (var preset in Presets)
            {
                preset.Toppings = new List<ToppingModel>();
                foreach (var menuPizzaTopping in preset.PizzaMenuToppings)
                {
                    preset.Toppings.Add(menuPizzaTopping.Topping);
                }

                if (preset.Name == "Custom")
                {
                    preset.Price = 0;
                }
                else
                {
                    preset.Price = preset.CalculatePrice();
                }
            }
        }
    }
}