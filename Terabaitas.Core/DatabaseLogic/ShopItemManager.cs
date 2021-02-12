using System.Collections.Generic;
using System.Linq;
using Terabaitas.Data;
using Terabaitas.Models;

namespace Terabaitas.Core
{
    public class ShopItemManager : IDbAccess<ShopItem>
    {
        private AppDbContext appDbContext;

        public ShopItemManager(AppDbContext dbcontext) => appDbContext = dbcontext;

        public ShopItem Get(int i)
        {
            return appDbContext.ShopItems.FirstOrDefault(e => e.Id == i);
        }

        public List<ShopItem> GetAll()
        {
            return appDbContext.ShopItems.ToList();
        }

        public async void Add(ShopItem entity)
        {
            appDbContext.ShopItems.Add(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async void Edit(ShopItem entity)
        {
            appDbContext.ShopItems.Update(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async void Remove(ShopItem entity)
        {
            appDbContext.ShopItems.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }
}
