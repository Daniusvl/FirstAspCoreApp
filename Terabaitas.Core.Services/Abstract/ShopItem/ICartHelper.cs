using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Terabaitas.Core.Domain;

namespace Terabaitas.Core.Services.Abstract
{
    public interface ICartHelper
    {
        void FixNull(ISession session, ref List<(ShopItem, int)> cart);
        string GetCartStr(ISession session);
        List<(ShopItem, int)> GetCart(ISession session);
        void SetCart(ISession session, List<(ShopItem, int)> cart);
        int IsInCart(ISession session, ShopItem item);
        bool AddToCart(ISession session, ShopItem item);
        bool RemoveFromCart(ISession session, ShopItem item);
    }
}
