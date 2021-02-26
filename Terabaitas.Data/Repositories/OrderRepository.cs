using System.Collections.Generic;
using System.Linq;
using Terabaitas.Data.Entities;
using Terabaitas.Data.Repositories.Abstract;

namespace Terabaitas.Data.Repositories
{
    public class OrderRepository : IEntityRepository<OrderEntity>
    {
        private AppDbContext appDbContext;

        public OrderRepository(AppDbContext dbcontext) => appDbContext = dbcontext;

        public OrderEntity Get(int i)
        {
            return appDbContext.Orders.FirstOrDefault(e => e.Id == i);
        }

        public List<OrderEntity> GetAll()
        {
            return appDbContext.Orders.ToList();
        }

        public async void Add(OrderEntity entity)
        {
            appDbContext.Orders.Add(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async void Edit(OrderEntity entity)
        {
            var ent = Get(entity.Id);
            ent.OrderedProducts = ent.OrderedProducts;
            ent.UsersId = ent.UsersId;
            appDbContext.Orders.Update(ent);
            await appDbContext.SaveChangesAsync();
        }

        public async void Remove(OrderEntity entity)
        {
            appDbContext.Orders.Remove(Get(entity.Id));
            await appDbContext.SaveChangesAsync();
        }
    }
}
