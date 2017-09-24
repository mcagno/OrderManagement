namespace OrderManagement.Domain
{
    public class OrderLine
    {

        public ProductID ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public BaseID<int> ID { get; set; }
    }
}