using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Business;
using ShoeShop.Data.Models;

namespace ShoeShop.Presentation
{
    class Display
    {
        private int closeOperationId = 8;
        private ShoeShopBusiness shoeShopBusiness = new ShoeShopBusiness();

        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string(' ', 12) + "SHOE SHOP MENU" + new string(' ', 12));
            Console.WriteLine(new string('~', 40));
            Console.WriteLine("1. List all shoes");
            Console.WriteLine("2. List all shoes by category");
            Console.WriteLine("3. List all shoes by brand");
            Console.WriteLine("4. List all customer names and their orders");
            Console.WriteLine("5. Add shoe");
            Console.WriteLine("6. Delete shoe");
            Console.WriteLine("7. Update shoe");
            Console.WriteLine("8. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                Console.WriteLine();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        Console.WriteLine();
                        break;
                    case 2:
                        ListAllShoesByCategory();
                        break;
                    case 3:
                        ListAllShoesByBrand();
                        break;
                    case 4:
                        ListCustomersAndOrders();
                        break;
                    case 5:
                        AddShoe();
                        break;
                    case 6:
                        DeleteShoe();
                        break;
                    case 7:
                        UpdateShoe();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            Console.WriteLine(new string('~', 40));
            var shoes = shoeShopBusiness.GetAll();
            foreach (var shoe in shoes)
            {
                Console.WriteLine($"{shoe.Id} {shoe.Name} {shoe.Brand} {shoe.Price} {shoe.Quantity} {shoe.CategoryId}");
            }
        }
        private void ListAllShoesByCategory()
        {
            int id = 0;
            List<int> idscategory = new List<int>();
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string(' ', 8) + "Please select category ID" + new string(' ', 8));
            Console.WriteLine(new string('~', 40));
            
            var categories = shoeShopBusiness.ShoeCategories();
            foreach (var x in categories)
            {
                Console.WriteLine($"{x.Id}. - {x.Name}");
                idscategory.Add(x.Id);
            }
            Console.WriteLine();

            id = int.Parse(Console.ReadLine());
            if (idscategory.Contains(id)) { }
            else
            {
                while (!idscategory.Contains(id))
                {
                    Console.WriteLine("Please select a correct ID!");
                    id = int.Parse(Console.ReadLine());
                }
            }
            var shoes = shoeShopBusiness.GetShoeByCategory(id);
            foreach (var shoe in shoes)
            {
                Console.WriteLine($"{shoe.Id} {shoe.Name} {shoe.Brand} {shoe.Price} {shoe.Quantity}");
            }
            Console.WriteLine();
            
        }
        private void ListAllShoesByBrand()
        {
            bool check = false;
            Console.WriteLine(new string('~', 40));
            Console.WriteLine(new string(' ', 8) + "Please type a shoe brand" + new string(' ', 8));
            Console.WriteLine(new string('~', 40));

            var shoes = shoeShopBusiness.GetAll();
            string brand = Console.ReadLine();
            foreach (var shoe in shoes)
            {
                if (shoe.Brand == brand)
                {
                    check = true;
                }
            }
            if (check == true)
            {
                var ShoesByBrand = shoeShopBusiness.GetShoeByBrand(brand);
                foreach (var shoe in ShoesByBrand)
                {
                    Console.WriteLine($"{shoe.Id} {shoe.Name} {shoe.Brand} {shoe.Price} {shoe.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Brand not found!");
            }
        }
        private void ListCustomersAndOrders()
        {
            var customers = shoeShopBusiness.GetCustomers();
            var orders = shoeShopBusiness.GetOrders();
            var shoes = shoeShopBusiness.ShoesOrdersModels();
            for (int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine($"Client: {customers[i].Name} CliendID:{orders[i].CustomerId}/ OrderID: {orders[i].Id} {orders[i].OrderDate} {shoes[i].Brand} {shoes[i].Name}");
            }
        }
        private void AddShoe()
        {
            List<int> idscategory = new List<int>();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            var categories = shoeShopBusiness.ShoeCategories();
            foreach (var x in categories)
            {
                Console.WriteLine($"{x.Id}. {x.Name}");
                idscategory.Add(x.Id);
            }
            Console.Write("Select category ID: ");
            int id = int.Parse(Console.ReadLine());
            if (idscategory.Contains(id)) { }
            else
            {
                while (!idscategory.Contains(id))
                {
                    Console.WriteLine("Please select a correct ID!");
                    id = int.Parse(Console.ReadLine());
                }
            }
            Shoe shoe = new Shoe();
            shoe.Name = name;
            shoe.Brand = brand;
            shoe.Price = price;
            shoe.Quantity = quantity;
            shoe.CategoryId = id;
            shoeShopBusiness.AddShoe(shoe);
        }
        private void DeleteShoe()
        {
            Console.Write("Enter ID to remove shoe: ");
            int id = int.Parse(Console.ReadLine());
            shoeShopBusiness.DeleteShoe(id);
            Console.WriteLine($"Shoe with ID:{id} was successfully deleted");
        }
        private void UpdateShoe()
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Shoe shoe = shoeShopBusiness.GetShoe(id);
            if (shoe != null)
            {
                List<int> idscategory = new List<int>();
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                var categories = shoeShopBusiness.ShoeCategories();
                foreach (var x in categories)
                {
                    Console.WriteLine($"{x.Id}. {x.Name}");
                    idscategory.Add(x.Id);
                }
                Console.Write("Select category ID: ");
                int categoryid = int.Parse(Console.ReadLine());
                if (idscategory.Contains(categoryid)) { }
                else
                {
                    while (!idscategory.Contains(categoryid))
                    {
                        Console.WriteLine("Please select a correct ID!");
                        categoryid = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();

                shoe.Name = name;
                shoe.Brand = brand;
                shoe.Price = price;
                shoe.Quantity = quantity;
                shoe.CategoryId = categoryid;
                shoeShopBusiness.UpdateShoe(shoe);
            }
            else
            {
                Console.WriteLine($"Shoe with ID: {id} not found");
                Console.WriteLine();
            }
        }
    }
}
