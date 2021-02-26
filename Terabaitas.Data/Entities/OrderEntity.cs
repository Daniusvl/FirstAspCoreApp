using System;
using Terabaitas.Data.Entities.Abstract;

namespace Terabaitas.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string UsersId { get; set; }
        public string OrderedProducts { get; set; }
    }
}
