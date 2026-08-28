using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Domain.Entities
{
    public enum OrderStatus
    {
        New,
        Confirmed,
        Paid,
        Shipped,
        Cancelled

    }
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public decimal TotalAmount => _items.Sum(item => item.Price * item.Quantity);
        protected Order() { }
        public void AddItem(Product product , int quantity)
        {
            if( quantity == 0 || quantity < 0)
            {
                throw new ArgumentException($"Quantity of {nameof(product)} can not be null or negative");

            }
            if(Status != OrderStatus.New)
            {
                throw new ArgumentException("You can not add product if order isnt new");
            }
            if(!_items.Any())
            {
                throw new ArgumentException("Order is empty");
            }
            var existingItem = _items.FirstOrDefault(item => item.ProductId == product.Id);
            if( existingItem != null )
            {
                existingItem.AddQuantity(quantity);
            }
            else
            {
                _items.Add(new OrderItem(product.Id, product.Price, product.StockQuantity));
            }
        }
        public Order(Guid customerId)
        {
            if(customerId == Guid.Empty)
            {
                throw new ArgumentException("Customer id can not be empty");
            

            }
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Status = OrderStatus.New;
            CreatedAt = DateTime.Now;
        }
        public void Confirm()
        {
            if( Status != OrderStatus.New )
            {
                throw new ArgumentException("Order must to have new status to confirm it");
            }
            Status = OrderStatus.Confirmed;
        }
        public void Pay()
        {
            if(Status !=  OrderStatus.Confirmed)
            {
                throw new ArgumentException("Order must to be confirmed to pay ");
            }
            Status = OrderStatus.Paid;
        }
        public void Cancel()
        {
            if(Status == OrderStatus.Shipped)
            {
                throw new ArgumentException("Shipped order can not be cancelled...");
            }
            Status = OrderStatus.Cancelled;
        }
       
    }
}
