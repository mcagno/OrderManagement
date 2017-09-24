using System.Linq;
using OrderManagement.Domain;
using Order = OrderManagement.Domain.Order;
using OrderLine = OrderManagement.Domain.OrderLine;

namespace OrderManagement.Assembler
{
    public class OrderAssembler : IAssembler<DTO.Order, Order>
    {
        

        public DTO.Order ToDto(Order domainObject)
        {
            var order = new DTO.Order
            {
                ID = domainObject.ID.ID,
                Code = domainObject.Code,
                CustomerID = domainObject.CustomerID.ID,
                Created = domainObject.Created
            };
            foreach (OrderLine objectLine in domainObject.Lines)
            {
                var orderLine = new DTO.OrderLine()
                {
                    ID = objectLine.ID.ID,
                    ProductID = objectLine.ProductID.ID,
                    Price = objectLine.Price,
                    Quantity = objectLine.Quantity
                };
                
                order.Lines.Add(orderLine );
            }
            return order;
        }

        public Order ToDomainObject(DTO.Order dto)
        {
            var order = new Order
            {
                ID = new OrderID(dto.ID),
                CustomerID = new CustomerID(dto.CustomerID),
                Created = dto.Created,
                Code = dto.Code,
            };


            var linesToRemove = order.Lines.Select(x => x.ID.ID).Except(dto.Lines.Select(x => x.ID));
            foreach (int id in linesToRemove)
            {
                order.RemoveLine(id);
            }

            var linesToUpdate = dto.Lines.Where(x => order.Lines.Any(c => c.ID.ID == x.ID));
            foreach (DTO.OrderLine orderLine in linesToUpdate)
            {
                order.UpdateLine(orderLine.ID, orderLine.ProductID, orderLine.Quantity, orderLine.Price);
            }

            var linesToAdd = dto.Lines.Where(x => order.Lines.All(c => c.ID.ID != x.ID));
            foreach (DTO.OrderLine orderLine in linesToAdd)
            {
                order.AddLine(orderLine.ID, orderLine.ProductID, orderLine.Quantity, orderLine.Price);
            }

            return order;


        }
    }

   
}
