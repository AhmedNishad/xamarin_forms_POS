using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Core
{
    public class Product
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public string Name { get; set; }

        public Product(string name, decimal price, int id)
        {
            this.UnitPrice = price;
            this.Name = name;
            this.Id = id;
        }
    }
}
