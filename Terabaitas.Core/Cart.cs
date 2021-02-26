using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Terabaitas.Models;
using Newtonsoft.Json;

namespace Terabaitas.Core
{
    public class Cart
    {

        public void FixNull(ISession session, ref List<(ShopItemEntity, int)> cart)
        {
            if (cart is null)
            {
                cart = new List<(ShopItemEntity, int)>();
                SetCart(session, new List<(ShopItemEntity, int)>());
            }
        }

        public string GetCartStr(ISession session)
        {
            return session.GetString("Cart");
        }

        public List<(ShopItemEntity, int)> GetCart(ISession session)
        {
            List<(ShopItemEntity, int)> cart = null;

            string json = GetCartStr(session);

            if (json != null && json != string.Empty)
                cart = JsonConvert.DeserializeObject<List<(ShopItemEntity, int)>>(json);

            FixNull(session, ref cart);

            return cart;
        }

        public void SetCart(ISession session, List<(ShopItemEntity, int)> cart)
        {
            if (cart is null)
                return;

            string serialized = JsonConvert.SerializeObject(cart);

            session.SetString("Cart", serialized);
        }

        public int IsInCart(ISession session, ShopItemEntity item)
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

        public bool AddToCart(ISession session, ShopItemEntity item)
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
                if(x.Item1.Quantity > x.Item2)
                {
                    x.Item2++;
                    cart[i] = x;
                }
            }

            SetCart(session, cart);

            return true;
        }

        public bool RemoveFromCart(ISession session, ShopItemEntity item)
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
    }
}
