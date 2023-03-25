using System;
using System.Collections.Generic;

namespace ShoeShop.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Shoe = new HashSet<Shoe>();
        }
        public Category(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Shoe> Shoe { get; set; }
    }
}
