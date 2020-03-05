using System;

namespace POS.Core
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
    }
}
