using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OrderManagement.DTO;

namespace OrderManagementClientAPI
{
    public class Communicator : ICommunicator
    {
        private readonly HttpClient _client = new HttpClient();
        private const string BaseURI = "http://localhost:56298/";

        public Communicator()
        {
            InitializeClient();
        }

        public void InitializeClient()
        {
            _client.BaseAddress = new Uri(BaseURI);
        }

        public bool InsertOrder(Order order)
        {
            return Post("api/Order", order).Result;
        }

        public bool DeleteOrder(Order order)
        {
            return Delete($"api/Order/{order.ID}").Result;
        }

        public bool UpdateOrder(Order order)
        {
            return Post("api/Order", order).Result;
        }

        public IEnumerable<Product> GetProducts()
        {
            var task = Get<IEnumerable<Product>>("api/Product");
            return task.Result;
        }

        public IEnumerable<Order> GetOrders(int customerID)
        {
            
            var task = Get<IEnumerable<Order>>($"api/Order/GetByCustomerID/{customerID}");
            return task.Result;
        }

        public Order GetOrder(int orderID)
        {
            var task = Get<Order>($"api/Order/{orderID}");
            return task.Result;
        }

        public async Task<T> Get<T>(string uri) 
        {
            T result = default(T);
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();               
            }
            return result;
        }

        public async Task<bool> Post<T>(string uri, T body)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(uri, body);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Put<T>(string uri, T body)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, body);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string uri)
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }
    }

    public interface ICommunicator
    {
        bool InsertOrder(Order order);
        bool DeleteOrder(Order order);
        bool UpdateOrder(Order order);
        IEnumerable<Product> GetProducts();
        IEnumerable<Order> GetOrders(int customerID);
        Order GetOrder(int id);
    }
}
