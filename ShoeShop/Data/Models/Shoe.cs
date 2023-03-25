using System;
using System.Collections.Generic;

namespace ShoeShop.Data.Models
{
    public partial class Shoe
    {
        public Shoe()
        {
            Order = new HashSet<Order>();
        }
        public Shoe(int id, string name, string brand, decimal price, int quantity, int categoryid)
        {
            this.Id = id;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Quantity = quantity;
            this.CategoryId = categoryid;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        
        
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
