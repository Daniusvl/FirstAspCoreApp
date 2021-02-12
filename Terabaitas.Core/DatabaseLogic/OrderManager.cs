using System.Collections.Generic;
using System.Linq;
using Terabaitas.Data;
using Terabaitas.Models;

namespace Terabaitas.Core
{
    public class OrderManager : IDbAccess<Order>
    {
        private AppDbContext appDbContext;

        public OrderManager(AppDbContext dbcontext) => appDbContext = dbcontext;

        public Order Get(int i)
        {
            return appDbContext.Orders.FirstOrDefault(e => e.Id == i);
        }

        public List<Order> GetAll()
        {
            return appDbContext.Orders.ToList();
        }

        public async void Add(Order entity)
        {
            appDbContext.Orders.Add(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async void Edit(Order entity)
        {
            appDbContext.Orders.Update(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async void Remove(Order entity)
        {
            appDbContext.Orders.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }
}
