using System;

namespace Terabaitas.Core.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string UsersId { get; set; }
        public string OrderedProducts { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
