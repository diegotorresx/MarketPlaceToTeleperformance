﻿namespace TestProyectBackEnd.Models
{
    public class OrderItems
    {
        public int ID { get; set; } 
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
