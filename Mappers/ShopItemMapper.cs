using Terabaitas.Core.Domain;
using Terabaitas.Data.Entities;
using Terabaitas.Models;

namespace Terabaitas.Mappers
{
    public static class ShopItemMapper
    {
        public static ShopItemEntity ToEntity(this ShopItem item)
        {
            if (item is null)
                return null;

            return new ShopItemEntity
            {
                Id = item.Id,
                DateCreated = item.DateCreated,
                Name = item.Name,
                Description = item.Description,
                Type = item.Type,
                Price = item.Price,
                Quantity = item.Quantity,
                Images = item.Images
            };
        }

        public static ShopItemModel ToModel(this ShopItem item)
        {
            if (item is null)
                return null;

            return new ShopItemModel
            {
                Id = item.Id,
                DateCreated = item.DateCreated,
                Name = item.Name,
                Description = item.Description,
                Type = item.Type,
                Price = item.Price,
                Quantity = item.Quantity,
                Images = item.Images
            };
        }

        public static ShopItem ToDomain(this ShopItemEntity item)
        {
            if (item is null)
                return null;

            return new ShopItem
            {
                Id = item.Id,
                DateCreated = item.DateCreated,
                Name = item.Name,
                Description = item.Description,
                Type = item.Type,
                Price = item.Price,
                Quantity = item.Quantity,
                Images = item.Images
            };
        }

        public static ShopItem ToDomain(this ShopItemModel item)
        {
            if (item is null)
                return null;

            return new ShopItem
            {
                Id = item.Id,
                DateCreated = item.DateCreated,
                Name = item.Name,
                Description = item.Description,
                Type = item.Type,
                Price = item.Price,
                Quantity = item.Quantity,
                Images = item.Images
            };
        }
    }
}
