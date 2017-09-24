using System.Collections.Generic;
using System.Web.Http;
using OrderManagement.Assembler;
using OrderManagement.Domain;
using OrderManagement.Repository;
using DTO = OrderManagement.DTO;

namespace OrderManagementBackend.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IReadOnlyRepository<Product> _repository;
        private readonly IAssembler<DTO.Product, Product> _assembler;

        public ProductController(IReadOnlyRepository<Product> repository, IAssembler<DTO.Product, Product> assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }

        // GET: api/Article
        public IEnumerable<DTO.Product> Get()
        {
            IReadOnlyCollection<Product> products = _repository.Get();
            List<DTO.Product> dtos = new List<DTO.Product>();
            foreach (var product in products)
            {
                var dto = _assembler.ToDto(product);
                dtos.Add(dto);
            }
            return dtos;
        }

        // GET: api/Article/5
        public DTO.Product Get(int id)
        {
            var product = _repository.Get(id);
            if (product != null)
            {
                return _assembler.ToDto(product);
            }
            return null;
        }

    }
}
