using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Data;
using ShoeShop.Data.Models;

namespace ShoeShop.Business
{
    public class ShoeShopBusiness
    {
        private ShopData manager = new ShopData();

        public List<Shoe> GetAll()
        {
            return manager.GetAllShoes();
        }

        public List<Category> ShoeCategories()
        {
            return manager.ShoeCategory();
        }

        public List<Shoe> GetShoeByCategory(int id)
        {
            return manager.GetAllShoesByCategory(id);
        }

        public List<Shoe> GetShoeByBrand(string brand)
        {
            return manager.GetAllShoesByBrand(brand);
        }

        public List<Customer> GetCustomers()
        {
            return manager.GetCustomersNames();
        }

        public List<Order> GetOrders()
        {
            return manager.GetOrders();
        }

        public List<Shoe> ShoesOrdersModels()
        {
            return manager.ShoesOrdersModels();
        }

        public void AddShoe(Shoe shoe)
        {
            manager.AddShoe(shoe);
        }

        public void DeleteShoe(int id)
        {
            manager.DeleteShoe(id);
        }

        public Shoe GetShoe(int id)
        {
            return manager.GetShoe(id);
        }

        public void UpdateShoe(Shoe shoe)
        {
            manager.UpdateShoe(shoe);
        }
    }
}
