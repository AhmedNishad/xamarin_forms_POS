using System;
using System.Collections.Generic;
using System.Text;

namespace POS._Core
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

        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product("Nike", 124.2m, 1),
                new Product("Adidas", 156.2m, 2),
                new Product("Puma", 121.2m, 3),
                new Product("Reebok", 115.2m, 4),
                new Product("Yeazy", 195.2m, 5),
                new Product("DSI", 71.2m, 6),
                new Product("Bata", 24.2m, 7),
                new Product("Radical", 800, 8)
            };
        }

        public override string ToString()
        {
            return Name + " - " + UnitPrice.ToString() + "$";
        }
    }
    }

