using System.Collections.Generic;
using Terabaitas.Core.Domain;

namespace Terabaitas.Core.Services.Abstract
{
    public interface IOrderService
    {
        void Add(Order entity);
        void Edit(Order entity);
        Order Get(int i);
        List<Order> GetAll();
        void Remove(Order entity);
    }
}
