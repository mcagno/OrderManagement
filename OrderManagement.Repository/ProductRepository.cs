using System.Collections.Generic;
using OrderManagement.Domain;

namespace OrderManagement.Repository
{

    public class ProductRepository : IReadOnlyRepository<Product>
    {

        //This static list act as a simulation of a container where the orders are stored (i.e. DB)
        private static readonly List<Product> Products = new List<Product>();

        static ProductRepository()
        {
            var product = new Product
            {
                ID = new ProductID(1),
                Name = "Pencil",
                Description = "Black pencil"
            };
            Products.Add(product);

            product = new Product
            {
                ID = new ProductID(2),
                Name = "Rubber",
                Description = "Soft rubber"
            };
            Products.Add(product);

            product = new Product
            {
                ID = new ProductID(3),
                Name = "Ruler",
                Description = "15 inch. ruler"
            };
            Products.Add(product);
        }
    

        public Product Get(int id)
        {
            return Products.Find(x => x.ID == new ProductID(id));
        }

        public IReadOnlyCollection<Product> Get()
        {
            return Products;
        }

    }
}
