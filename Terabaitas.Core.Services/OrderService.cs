using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Core.Domain;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Core.Services.Mappers;
using Terabaitas.Data.Entities;
using Terabaitas.Data.Repositories.Abstract;

namespace Terabaitas.Core.Services
{
    public class OrderService : IOrderService, IOrderHelper
    { 

        private readonly IEntityRepository<OrderEntity> orderRepository;
        private readonly IEntityRepository<ShopItemEntity> shopItemRepository;
        private readonly IUserService userService;

        public OrderService(IEntityRepository<OrderEntity> order_repository, IEntityRepository<ShopItemEntity> shop_item_repository, IUserService user_service)
        {
            orderRepository = order_repository;
            shopItemRepository = shop_item_repository;
            userService = user_service;
        }

        public void Add(Order entity)
        {
            orderRepository.Add(entity.ToEntity());
        }

        public void Edit(Order entity)
        {
            orderRepository.Edit(entity.ToEntity());
        }

        public Order Get(int i)
        {
            return orderRepository.Get(i).ToDomain();
        }

        public List<Order> GetAll()
        {
            var output = new List<Order>();
            var entities = orderRepository.GetAll();
            foreach (var item in entities)
            {
                output.Add(item.ToDomain());
            }
            return output;
        }

        public void Remove(Order entity)
        {
            orderRepository.Remove(entity.ToEntity());
        }

        public async Task<User> GetUser(int order_id)
        {
            if (order_id < 0)
                return null;

            var order = Get(order_id);

            if (order is null)
                return null;

            return await userService.GetUserById(order.UsersId);
        }

        public List<(ShopItem, int)> GetProducts(int order_id)
        {
            if (order_id < 0)
                return null;

            var order = Get(order_id);

            if (order is null)
                return null;

            var ordered_products = JsonConvert.DeserializeObject<List<(ShopItem, int)>>(order.OrderedProducts);

            return ordered_products;
        }

        public bool CanDeliver(int order_id)
        {
            if (order_id < 0)
                return false;

            var products = GetProducts(order_id);

            if (products is null)
                return false;

            foreach (var item in products)
            {
                var product = shopItemRepository.Get(item.Item1.Id);
                if (product.Quantity < item.Item2)
                    return false;
            }

            return true;
        }

        public void FixProductQuantities(int order_id)
        {
            if (order_id < 0)
                return;

            var products = GetProducts(order_id);

            if (products is null)
                return;

            foreach (var item in products)
            {
                var product = shopItemRepository.Get(item.Item1.Id);
                product.Quantity -= item.Item2;
                shopItemRepository.Edit(product);
            }
        }
    }
}
