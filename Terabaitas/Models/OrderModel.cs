using System;

namespace Terabaitas.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UsersId { get; set; }
        public string OrderedProducts { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
