using Terabaitas.Core.Domain;
using Terabaitas.Models;

namespace Terabaitas.UI.Mappers
{
    public static class OrderMapper
    {
        public static OrderModel ToModel(this Order order)
        {
            if (order is null)
                return null;

            return new OrderModel
            {
                Id = order.Id,
                DateCreated = order.DateCreated,
                OrderedProducts = order.OrderedProducts,
                UsersId = order.UsersId
            };
        }

        public static Order ToDomain(this OrderModel order)
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
