using System;

namespace Terabaitas.Core.Domain
{
    public class ShopItem
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; }
    }
}
