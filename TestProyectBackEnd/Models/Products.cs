﻿namespace TestProyectBackEnd.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name  { get; set; } 
        public string ManuFacturer { get; set;}
        public decimal UnitPrice { get; set;}
        public decimal Discount { get; set;}
        public int Quantity { get; set;}
        public DateTime ExpDate { get; set;}
        public string ImageURL { get; set;}
        public int Status { get; set;}
        public string Type { get; set;}
    }
}
