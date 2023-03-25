using System;
using System.Collections.Generic;

namespace ShoeShop.Data.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShoeId { get; set; }
        public int CustomerId { get; set; }

        public Order(int id, DateTime orderdate, int shoeid, int customerid)
        {
            this.Id = id;
            this.OrderDate = orderdate;
            this.ShoeId = shoeid;
            this.CustomerId = customerid;
        }
        public virtual Customer Customer { get; set; }
        public virtual Shoe Shoe { get; set; }
    }
}
