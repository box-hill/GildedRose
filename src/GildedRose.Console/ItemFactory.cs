using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console.Items;

namespace GildedRose.Console
{
    public static class ItemFactory
    {
        // Initialize dictionary with keys as the item name, and values as a function delegate
        private static readonly Dictionary<string, Func<UpdatableItem>> _itemDictionary =
            new Dictionary<string, Func<UpdatableItem>>
            {
                {"Aged Brie", () => new AgedBrie()},
                {"Backstage passes to a TAFKAL80ETC concert", () => new BackstagePass()},
                {"Sulfuras, Hand of Ragnaros", () => new Sulfuras()},
                {"Conjured Mana Cake", () => new Conjured()}
            };

        public static UpdatableItem CreateItem(string name, int sellIn, int quality)
        {
            // Create the item based on item's name
            if (!_itemDictionary.TryGetValue(name, out var itemFactory))
            {
                itemFactory = () => new UpdatableItem();
            }

            UpdatableItem item = itemFactory();
            item.Name = name;
            item.SellIn = sellIn;
            item.Quality = quality;
            return item;
        }

    }
}
