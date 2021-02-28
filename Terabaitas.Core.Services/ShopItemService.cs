using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Terabaitas.Core.Domain;
using Terabaitas.Core.Services.Abstract;
using Terabaitas.Core.Services.Mappers;
using Terabaitas.Data.Entities;
using Terabaitas.Data.Repositories.Abstract;

namespace Terabaitas.Core.Services
{
    public class ShopItemService : IShopItemService, ICartHelper
    {

        private readonly IEntityRepository<ShopItemEntity> shopItemRepository;

        public ShopItemService(IEntityRepository<ShopItemEntity> repository)
        {
            shopItemRepository = repository;
        }

        public void Add(ShopItem entity)
        {
            shopItemRepository.Add(entity.ToEntity());
        }

        public void Edit(ShopItem entity)
        {
            shopItemRepository.Edit(entity.ToEntity());
        }

        public ShopItem Get(int i)
        {
            return shopItemRepository.Get(i).ToDomain();
        }

        public List<ShopItem> GetAll()
        {
            var output = new List<ShopItem>();
            var entities = shopItemRepository.GetAll();
            foreach (var item in entities)
            {
                output.Add(item.ToDomain());
            }
            return output;
        }

        public void Remove(ShopItem entity)
        {
            shopItemRepository.Remove(entity.ToEntity());
        }

        public bool AddToCart(ISession session, ShopItem item)
        {
            if (item is null)
                return false;

            var cart = GetCart(session);

            FixNull(session, ref cart);

            int i = IsInCart(session, item);

            if (i == -1)
            {
                cart.Add((item, 1));
            }
            else
            {
                var x = cart[i];
                if (x.Item1.Quantity > x.Item2)
                {
                    x.Item2++;
                    cart[i] = x;
                }
            }

            SetCart(session, cart);

            return true;
        }

        public void FixNull(ISession session, ref List<(ShopItem, int)> cart)
        {
            if (cart is null)
            {
                cart = new List<(ShopItem, int)>();
                SetCart(session, new List<(ShopItem, int)>());
            }
        }

        public List<(ShopItem, int)> GetCart(ISession session)
        {
            List<(ShopItem, int)> cart = null;

            string json = GetCartStr(session);

            if (json != null && json != string.Empty)
                cart = JsonConvert.DeserializeObject<List<(ShopItem, int)>>(json);

            FixNull(session, ref cart);

            return cart;
        }

        public string GetCartStr(ISession session)
        {
            return session.GetString("Cart");
        }

        public int IsInCart(ISession session, ShopItem item)
        {
            if (item is null)
                return -1;

            var cart = GetCart(session);

            FixNull(session, ref cart);

            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Item1.Id == item.Id)
                    return i;

            return -1;
        }

        public bool RemoveFromCart(ISession session, ShopItem item)
        {
            if (item is null)
                return false;

            var cart = GetCart(session);

            FixNull(session, ref cart);

            int i = IsInCart(session, item);

            if (i != -1)
            {
                var x = cart[i];
                if (x.Item2 <= 1)
                {
                    cart.RemoveAt(i);
                }
                else
                {
                    x.Item2--;
                    cart[i] = x;
                }
            }
            SetCart(session, cart);

            return true;
        }

        public void SetCart(ISession session, List<(ShopItem, int)> cart)
        {
            if (cart is null)
                return;

            string serialized = JsonConvert.SerializeObject(cart);

            session.SetString("Cart", serialized);
        }
    }
}
