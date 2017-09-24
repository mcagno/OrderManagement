using System;
using System.Collections.Generic;

namespace OrderManagement.DTO
{
    public class Order
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public int CustomerID { get; set; }

        public DateTime Created { get; set; }

        public List<OrderLine> Lines { get; } = new List<OrderLine>();
        
    }

    public class OrderLine
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
    }


    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
