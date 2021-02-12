using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Models;

namespace Terabaitas.Core
{
    public class OrderHelper
    {
        private IDbAccess<Order> order_manager;
        private IAccountManager<User> acc_manager;
        private IDbAccess<ShopItem> shop_item_manager;

        public OrderHelper(IDbAccess<Order> oManager, IDbAccess<ShopItem> iManager, IAccountManager<User> aManager)
        {
            order_manager = oManager;
            acc_manager = aManager;
            shop_item_manager = iManager;
        }

        public async Task<User> GetUser(int order_id)
        {
            if (order_id < 0)
                return null;

            var order = order_manager.Get(order_id);

            if (order is null)
                return null;

            return await acc_manager.GetUser(order.UsersId);
        }
        
        public List<(ShopItem, int)> GetProducts(int order_id)
        {
            if (order_id < 0)
                return null;

            var order = order_manager.Get(order_id);

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
                var product = shop_item_manager.Get(item.Item1.Id);
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
                var product = shop_item_manager.Get(item.Item1.Id);
                product.Quantity -= item.Item2;
                shop_item_manager.Edit(product);
            }
        }
    }
}
