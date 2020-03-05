using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Core
{
    public class Manager
    {
        public List<Product> Products { get =>  new List<Product>()
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

        public List<LineItem> Items { get; set; }

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public LineItem AddItem(int itemId,int productId, int quantity)
        {
            var item = new LineItem(itemId);
            item.Create(Products.FirstOrDefault(p => p.Id == productId), quantity);
            return item;
        }

        public LineItem UpdateItem(int itemId,int newQuantity)
        {
            var item = Items.FirstOrDefault(p => p.Id == itemId);
            item.Quantity = newQuantity;
            return item;
        }

        public void RemoveItem(int itemId)
        {
            Items.Remove(Items.FirstOrDefault(p => p.Id == itemId));
        }
    }
}
