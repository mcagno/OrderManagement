using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Domain
{
    public class Order
    {
        public OrderID ID { get; set; }

        public string Code { get; set; }

        public CustomerID CustomerID { get; set; }

        public DateTime Created { get; set; }

        private readonly List<OrderLine> _lines = new List<OrderLine>();

        public IReadOnlyCollection<OrderLine> Lines => _lines;
        public void AddLine(int id, int productID, int quantity, decimal price)
        {
            var orderLine = new OrderLine
            {
                ID = new OrderLineID(id),
                ProductID = new ProductID(productID),
                Price = price,
                Quantity = quantity
            };
            _lines.Add(orderLine);
        }

        public void RemoveLine(int id)
        {
            _lines.RemoveAll(x => x.ID == new OrderLineID(id));
        }

        public bool UpdateLine(int id, int productID, int quantity, decimal price)
        {
            var orderLine = _lines.Find(x => x.ID == new OrderLineID(id));
            if (orderLine != null)
            {
                orderLine.ProductID = new ProductID(productID);
                orderLine.Quantity = quantity;
                orderLine.Price = price;
                return true;
            }
            return false;
        }

        public void ClearLines()
        {
            _lines.Clear();
        }

        public decimal GetTotal()
        {
            return _lines.Sum(o => o.Price * o.Quantity);
        }

    }
}
