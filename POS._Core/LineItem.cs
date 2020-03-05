using System;
using System.Collections.Generic;

namespace POS._Core
{
    public class LineItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal Amount { get => Product.UnitPrice * Quantity; }
        public int Quantity { get; set; }
        public LineItem(int id)
        {
            this.Id = id;
        }
        public LineItem Create(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            return this;
        }

        public override string ToString()
        {
            return Product.Name;
        }

        public static List<LineItem> GetSampleData()
        {
            var products = Product.GetProducts();
            return new List<LineItem>()
            {
                new LineItem(1).Create(products[0], 18),
                new LineItem(2).Create(products[2], 4)
            };
        }
    }
}
