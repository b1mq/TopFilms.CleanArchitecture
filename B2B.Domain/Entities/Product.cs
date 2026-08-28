using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Domain.Entities
{
    //rich domain model
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string SKU { get; private set; } = string.Empty; // Stock Keeping Unit
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        private Product() { } // EF Core constructor
        public void AddStock(int stockquantity)
        {
            if (stockquantity < 0)
            {
                throw new ArgumentOutOfRangeException("Quantity can not be negative");
            }
            StockQuantity += stockquantity;
        }
        public bool TryRemoveStock(int quantity)
        {
            if(quantity < 0)
            {
                throw new ArgumentException("Quantity can not be negative");
            }
            else if(StockQuantity > quantity)
            {
                throw new ArgumentException("Stock quantity is lesser than given quantity");
            }
            StockQuantity -= quantity;
            return true;
        }
        public void UpdatePrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negativ...");
            }
            Price = price;
        }
        public Product(string name,string description,string sku,decimal price,int stockquantity)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be empty");
            }
            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description can not be empty");
            }
            if(price < 0)
            {
                throw new ArgumentException("Price can not be negative");
            }
            if(stockquantity < 0)
            {
                throw new ArgumentException("Initial quantity can not be negative");
            }
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            SKU = sku;
            Price = price;
            StockQuantity = stockquantity;
        }


    }
}
