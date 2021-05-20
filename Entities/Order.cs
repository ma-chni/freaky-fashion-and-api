using System;
namespace FreakyFashion.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public uint TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Order()
        {
        }

        public Order(int customerId, int quantity, DateTime date, uint totalPrice)
        {
            CustomerId = customerId;
            Quantity = quantity;
            Date = date;
            TotalPrice = totalPrice;
        }

        public Order(int customerId, int quantity, DateTime date, uint totalPrice, int productId)
        {
            CustomerId = customerId;
            Quantity = quantity;
            Date = date;
            TotalPrice = totalPrice;
            ProductId = productId;
        }
    }
}
