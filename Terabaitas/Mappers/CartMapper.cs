using System.Collections.Generic;
using Terabaitas.Core.Domain;
using Terabaitas.Models;

namespace Terabaitas.UI.Mappers
{
    public static class CartMapper
    {
        public static List<(ShopItemModel, int)> ToModel(this List<(ShopItem, int)> list)
        {
            if (list is null)
                return null;

            var output = new List<(ShopItemModel, int)>();
            foreach (var item in list)
            {
                output.Add((item.Item1.ToModel(), item.Item2));
            }
            return output;
        }

        public static List<(ShopItem, int)> ToDomain(this List<(ShopItemModel, int)> list)
        {
            if (list is null)
                return null;

            var output = new List<(ShopItem, int)>();
            foreach (var item in list)
            {
                output.Add((item.Item1.ToDomain(), item.Item2));
            }
            return output;
        }
    }
}
