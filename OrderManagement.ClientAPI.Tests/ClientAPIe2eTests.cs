using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OrderManagement.DTO;
using OrderManagementClientAPI;

namespace OrderManagement.ClientAPI.Tests
{
    [TestFixture]
    [Category("e2e")]
    public class ClientAPIe2eTests
    {
        private OrderManager _orderManager;

        [SetUp]
        public void Setup()
        {
            _orderManager = new OrderManager(new Communicator());
        }

        [Test]
        public void GetProducts()
        {
            IEnumerable<Product> enumerable = _orderManager.GetProducts();
            Assert.AreEqual(3, enumerable.Count());
        }


        [Test]
        public void GetOrdersForCustomer1()
        {
            IEnumerable<Order> enumerable = _orderManager.GetOrders(1);
            Assert.AreEqual(3, enumerable.Count());
        }

        [Test]
        public void GetOrdersForCustomer2()
        {
            IEnumerable<Order> enumerable = _orderManager.GetOrders(2);
            Assert.AreEqual(0, enumerable.Count());
        }

        [Test]
        public void GetOrdersForCustomer3()
        {
            IEnumerable<Order> enumerable = _orderManager.GetOrders(3);
            Assert.AreEqual(1, enumerable.Count());
        }

        [Test]
        public void GetOrder1()
        {
            Order enumerable = _orderManager.GetOrder(1);
            Assert.AreEqual(1, enumerable.ID);
        }

        [Test]
        public void GetOrder2()
        {
            Order enumerable = _orderManager.GetOrder(2);
            Assert.AreEqual(2, enumerable.ID);
        }

        [Test]
        public void InsertOrder5()
        {
            Order order = new Order
            {
                ID = 5,
                CustomerID = 1,
                Code = "OrderCode1",
                Created = DateTime.Now
            };
            OrderLine line = new OrderLine
            {
                ProductID = 1,
                Quantity = 2
            };
            order.Lines.Add(line);
            OrderLine line2 = new OrderLine
            {
                ProductID = 2,
                Quantity = 3
            };

            order.Lines.Add(line2);
            bool result = _orderManager.InsertOrder(order);
            Assert.IsTrue(result);
            IEnumerable<Order> orders = _orderManager.GetOrders(1);
            Assert.AreEqual(4, orders.Count());
        }

        [Test]
        public void DeleteOrder5()
        {
            Order order = new Order
            {
                ID = 5,
                CustomerID = 1,
                Code = "OrderCode1",
                Created = DateTime.Now
            };
            bool result = _orderManager.DeleteOrder(order);
            Assert.IsTrue(result);
            Order resultOrder = _orderManager.GetOrder(5);
            Assert.IsNull(resultOrder);
        }

        [Test]
        public void UpdateOrder5()
        {
            Order order = new Order
            {
                ID = 5,
                CustomerID = 1,
                Code = "OrderCode1",
                Created = DateTime.Now
            };
            OrderLine line = new OrderLine
            {
                ProductID = 1,
                Quantity = 2
            };
            order.Lines.Add(line);
            bool result = _orderManager.InsertOrder(order);
            Assert.IsTrue(result);
            Order resultOrder = _orderManager.GetOrder(5);
            Assert.AreEqual(1, resultOrder.Lines.Count);
        }
    }
}
