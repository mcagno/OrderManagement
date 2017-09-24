using OrderManagement.Domain;

namespace OrderManagement.Assembler
{
    public class ProductAssembler : IAssembler<DTO.Product, Product>
    {
         

        public DTO.Product ToDto(Product domainObject)
        {
            DTO.Product dto = new DTO.Product
            {
                ID = domainObject.ID.ID,
                Name = domainObject.Name,
                Description = domainObject.Description
            };
            return dto;
        }

        public Product ToDomainObject(DTO.Product dto)
        {
            var product = new Product
            {
                ID = new ProductID(dto.ID),
                Name = dto.Name,
                Description = dto.Description
            };
            return product;
        }
    }

   
}
