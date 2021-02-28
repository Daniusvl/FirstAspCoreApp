using Terabaitas.Core.Domain;
using Terabaitas.Data.Entities;

namespace Terabaitas.Core.Services.Mappers
{
    public static class OrderMapper
    {
        public static OrderEntity ToEntity(this Order order)
        {
            if (order is null)
                return null;

            return new OrderEntity
            {
                Id = order.Id,
                DateCreated = order.DateCreated,
                OrderedProducts = order.OrderedProducts,
                UsersId = order.UsersId
            };
        }


        public static Order ToDomain(this OrderEntity order)
        {
            if (order is null)
                return null;

            return new Order
            {
                Id = order.Id,
                DateCreated = order.DateCreated,
                OrderedProducts = order.OrderedProducts,
                UsersId = order.UsersId
            };
        }
    }
}
