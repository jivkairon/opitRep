using System;
using System.Collections.Generic;

namespace ShoeShop.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }
        public Customer(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
