using System;

namespace Terabaitas.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UsersId { get; set; }
        public string OrderedProducts { get; set; }
        public string DateOrdered { get; set; } = DateTime.Now.ToString("dd/ MM/ yyyy");
    }
}
