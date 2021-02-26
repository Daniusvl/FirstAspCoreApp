using System.Collections.Generic;
using Terabaitas.Core.Domain;

namespace Terabaitas.Core.Services.Abstract
{
    public interface IShopItemService
    { 
        void Add(ShopItem entity);
        void Edit(ShopItem entity);
        ShopItem Get(int i);
        List<ShopItem> GetAll();
        void Remove(ShopItem entity);
    }
}
