using ShoeShop.Data.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeShop.Data
{
    public class ShopData
    {
        public List<Shoe> GetAllShoes()
        {
            var shoeList = new List<Shoe>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Shoe", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var shoe = new Shoe(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5)
                            );
                        shoeList.Add(shoe);
                    }
                }
                connection.Close();
            }
            return shoeList;
        }
        public List<Category> ShoeCategory()
        {
            var categories = new List<Category>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Category", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category category = new Category(
                            reader.GetInt32(0),
                            reader.GetString(1)
                            );
                        categories.Add(category);
                    }
                }
                connection.Close();
            }
            return categories;
        }
        public List<Shoe> GetAllShoesByCategory(int categoryId)
        {
            Shoe shoe = null;
            var shoeListByCategory = new List<Shoe>();

            ShoeCategory();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Shoe WHERE CategoryId=@categoryid", connection);
                command.Parameters.AddWithValue("categoryid", categoryId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shoe = new Shoe(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5)
                            );
                        shoeListByCategory.Add(shoe);
                    }
                }
                connection.Close();
            }
            return shoeListByCategory;
        }
        public List<Shoe> GetAllShoesByBrand(string brand)
        {
            Shoe shoe = null;
            var shoeListByBrand = new List<Shoe>();

            ShoeCategory();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Shoe WHERE Brand=@brand", connection);
                command.Parameters.AddWithValue("brand", brand);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shoe = new Shoe(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5)
                            );
                        shoeListByBrand.Add(shoe);
                    }
                }
                connection.Close();
            }
            return shoeListByBrand;
        }
        public List<Customer> GetCustomersNames()
        {
            var customers = new List<Customer>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT Name FROM Customer " +
                    "INNER JOIN [Order] On [Order].CustomerId = Customer.Id ",connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer(
                            reader.GetString(0));
                        customers.Add(customer);
                    }
                }
                connection.Close();
                
            }
            return customers;
        }
        public List<Order> GetOrders()
        {
            var orders = new List<Order>();
            
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM [Order]", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order(
                            reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3));
                        orders.Add(order);
                    }
                }
                connection.Close();
            }

            return orders;
        }
        public List<Shoe> ShoesOrdersModels()
        {
            
            var shoes = new List<Shoe>();
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * from Shoe " +
                    "JOIN [Order] ON [Order].ShoeId = Shoe.Id", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Shoe shoe = new Shoe(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5)
                            );
                        shoes.Add(shoe);
                    }
                }
                connection.Close();
            }

            return shoes;
        }
        public void AddShoe(Shoe shoe)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("INSERT INTO Shoe(Name,Brand,Price,Quantity,CategoryId) VALUES (@name,@brand,@price,@quantity,@categoryid)", connection);
                command.Parameters.AddWithValue("name", shoe.Name);
                command.Parameters.AddWithValue("brand", shoe.Brand);
                command.Parameters.AddWithValue("price", shoe.Price);
                command.Parameters.AddWithValue("quantity", shoe.Quantity);
                command.Parameters.AddWithValue("categoryid", shoe.CategoryId);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void DeleteShoe(int id)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("DELETE FROM Shoe WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Shoe GetShoe(int id)
        {
            Shoe shoe = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Shoe WHERE Id=@id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shoe = new Shoe(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDecimal(3),
                        reader.GetInt32(4),
                        reader.GetInt32(5)
                        );
                    }
                }
                connection.Close();
            }
            return shoe;
        }
        public void UpdateShoe(Shoe shoe)
        {
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("UPDATE Shoe SET Name=@name, Brand=@brand, Price=@price, " +
                    "Quantity=@quantity, CategoryId=@categoryid WHERE Id=@id", connection);
                command.Parameters.AddWithValue("name", shoe.Name);
                command.Parameters.AddWithValue("brand", shoe.Brand);
                command.Parameters.AddWithValue("price", shoe.Price);
                command.Parameters.AddWithValue("quantity", shoe.Quantity);
                command.Parameters.AddWithValue("categoryid", shoe.CategoryId);
                command.Parameters.AddWithValue("id", shoe.Id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
