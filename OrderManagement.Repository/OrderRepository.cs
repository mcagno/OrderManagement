using System.Collections.Generic;
using System.Linq;
using OrderManagement.Domain;

namespace OrderManagement.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetByCustomerID(int customerID);
    }

    public class OrderRepository : IOrderRepository
    {

        //This static list act as a simulation of a container where the orders are stored (i.e. DB)
        private static readonly List<Order> Orders = new List<Order>();

        static OrderRepository()
        {
            //Creation of some initial orders to fill the list
            var order = new Order
            {
                ID = new OrderID(1),
                CustomerID = new CustomerID(1)
            };
            order.AddLine(1, 1, 2, new decimal(10.5));
            order.AddLine(2, 2, 1, new decimal(5));
            order.AddLine(3, 3, 5, new decimal(6));
            Orders.Add(order);

            order = new Order
            {
                ID = new OrderID(2),
                CustomerID = new CustomerID(1)
            };
            order.AddLine(1, 1, 1, new decimal(10.5));
            order.AddLine(2, 2, 2, new decimal(5));
            Orders.Add(order);

            order = new Order
            {
                ID = new OrderID(3),
                CustomerID = new CustomerID(1)
            };
            order.AddLine(1, 2, 5, new decimal(5));
            Orders.Add(order);

            order = new Order
            {
                ID = new OrderID(4),
                CustomerID = new CustomerID(3)
            };
            order.AddLine(1, 1, 2, new decimal(10.5));
            order.AddLine(2, 2, 1, new decimal(5));
            Orders.Add(order);
        }

        public Order Get(int id)
        {
            return Orders.Find(x => x.ID == new OrderID(id));
        }

        public bool Write(Order entity)
        {
            int index = Orders.FindIndex(x => x.ID == entity.ID);
            if (index > 0)
            {
                //The order has been found
                Orders[index] = entity;
            }
            else
            {
                Orders.Add(entity);
            }
            return true;

        }

        public bool Delete(int id)
        {
            int index = Orders.FindIndex(x => x.ID == new OrderID(id));
            if (index > 0)
            {
                //The order has not been found
                Orders.RemoveAt(index);
                return true;
            }
            return false;


        }

        public IReadOnlyCollection<Order> Get()
        {
            return Orders;
        }

        public IEnumerable<Order> GetByCustomerID(int customerID)
        {
            return Orders.Where(x => x.CustomerID.ID == customerID);
        }
    }
}
