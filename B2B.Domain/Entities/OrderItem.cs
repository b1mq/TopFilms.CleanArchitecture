using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public OrderItem(Guid productId, decimal price, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
        protected OrderItem() { }
        internal void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
