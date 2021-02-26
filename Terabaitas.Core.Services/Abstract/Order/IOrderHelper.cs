using System.Collections.Generic;
using System.Threading.Tasks;
using Terabaitas.Core.Domain;

namespace Terabaitas.Core.Services.Abstract
{
    public interface IOrderHelper
    {
        Task<User> GetUser(int order_id);
        List<(ShopItem, int)> GetProducts(int order_id);
        bool CanDeliver(int order_id);
        void FixProductQuantities(int order_id);
    }
}
