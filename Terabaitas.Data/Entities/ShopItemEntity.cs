﻿using Terabaitas.Data.Entities.Abstract;

namespace Terabaitas.Data.Entities
{
    public class ShopItemEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; }
    }
}
