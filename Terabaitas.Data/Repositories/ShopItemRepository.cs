using System.Collections.Generic;
using System.Linq;
using Terabaitas.Data.Entities;
using Terabaitas.Data.Repositories.Abstract;

namespace Terabaitas.Data.Repositories
{
    public class ShopItemRepository : IEntityRepository<ShopItemEntity>
    {
        private AppDbContext appDbContext;

        public ShopItemRepository(AppDbContext dbcontext) => appDbContext = dbcontext;

        public ShopItemEntity Get(int i)
        {
            return appDbContext.ShopItems.FirstOrDefault(e => e.Id == i);
        }

        public List<ShopItemEntity> GetAll()
        {
            return appDbContext.ShopItems.ToList();
        }

        public async void Add(ShopItemEntity entity)
        {
            appDbContext.ShopItems.Add(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async void Edit(ShopItemEntity entity)
        {
            var ent = Get(entity.Id);
            ent.Name = entity.Name;
            ent.Type = entity.Type;
            ent.Description = entity.Description;
            ent.Price = entity.Price;
            ent.Quantity = entity.Quantity;
            ent.Images = entity.Images;
            appDbContext.ShopItems.Update(ent);
            await appDbContext.SaveChangesAsync();
        }

        public async void Remove(ShopItemEntity entity)
        {
            appDbContext.ShopItems.Remove(Get(entity.Id));
            await appDbContext.SaveChangesAsync();
        }
    }
}
