using System.Collections.Generic;
using System.Web.Http;
using OrderManagement.Repository;
using OrderManagement.Assembler;
using OrderManagement.Domain;
using DTO = OrderManagement.DTO;

namespace OrderManagementBackend.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderRepository _repository;
        private readonly IAssembler<DTO.Order, Order> _assembler;

        public OrderController(IOrderRepository repository, IAssembler<DTO.Order, Order> assembler)
        {
            _repository = repository;
            _assembler = assembler;
        }


        [Route("api/Order/GetByCustomerID/{id}")]
        public IEnumerable<DTO.Order> GetByCustomerID(int id)
        {
            List<DTO.Order> dtoList = new List<DTO.Order>();
            var orders = _repository.GetByCustomerID(id);
            foreach (var order in orders)
            {
                var dto = _assembler.ToDto(order);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public DTO.Order Get(int id)
        {
            Order order = _repository.Get(id);
            if (order != null)
            {
                return _assembler.ToDto(order);
            }
            return null;

        }

        public void Post([FromBody] DTO.Order order)
        {
            Order domainObject = _assembler.ToDomainObject(order);
            _repository.Write(domainObject);
        }
        public void Put(int id, [FromBody] DTO.Order order)
        {
            Order domainObject = _assembler.ToDomainObject(order);
            _repository.Write(domainObject);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
