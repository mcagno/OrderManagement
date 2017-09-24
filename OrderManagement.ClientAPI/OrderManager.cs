using System.Collections.Generic;
using OrderManagement.DTO;


namespace OrderManagementClientAPI
{
    public class OrderManager
    {
        private readonly ICommunicator _communicator;

        public OrderManager(ICommunicator communicator)
        {
            _communicator = communicator;
        }

        public bool InsertOrder(Order order)
        {
            return _communicator.InsertOrder(order);
        }

        public bool DeleteOrder(Order order)
        {
            return _communicator.DeleteOrder(order);
        }

        public bool UpdateOrder(Order order)
        {
            return _communicator.UpdateOrder(order);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _communicator.GetProducts();
        }

        public IEnumerable<Order> GetOrders(int customerID)
        {
            return _communicator.GetOrders(customerID);
        }

        public Order GetOrder(int id)
        {
            return _communicator.GetOrder(id);
        }
    }
}
