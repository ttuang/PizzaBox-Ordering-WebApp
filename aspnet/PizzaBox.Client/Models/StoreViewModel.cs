using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;


namespace PizzaBox.Client.Models
{
    public class StoreViewModel
    {
        private readonly StoreRepository storeRepo;

        public List<OrderModel> Orders { get; set; }
        public List<StoreModel> StoreList { get; set; }

        [Required(ErrorMessage = "Login Again")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must select a store")]
        public string StoreSelected { get; set; }

        public StoreViewModel() { }

        public StoreViewModel(PizzaBoxDBContext _dbContext)
        {
            storeRepo = new StoreRepository(_dbContext);

            StoreList = storeRepo.ReadAllStores();
        }

        public StoreModel Login(string storeName)
        {
            return storeRepo.Login(storeName);
        }

        public StoreModel CreateStore(string name)
        {
            if (storeRepo.CreateStore(name))
            {
                return Login(name);
            }
            return null;
        }

        public StoreViewModel OrderHistory(string storeName)
        {
            var storeViewModel = new StoreViewModel();
            storeViewModel.Orders = storeRepo.ReadOrders(storeName);
            return storeViewModel;
        }

        public StoreViewModel OrderHistory(string storeName, string CustomerName)
        {
            var storeViewModel = new StoreViewModel();
            storeViewModel.Orders = storeRepo.ReadOrders(storeName, CustomerName);
            return storeViewModel;
        }
    }
}