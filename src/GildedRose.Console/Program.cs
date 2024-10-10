using System.Collections.Generic;
using GildedRose.Console.Items;

namespace GildedRose.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");


            List<UpdatableItem> itemList = new List<UpdatableItem>
            {
                ItemFactory.CreateItem("+5 Dexterity Vest", 10, 20),
                ItemFactory.CreateItem("Aged Brie", 2, 0),
                ItemFactory.CreateItem("Elixir of the Mongoose", 5, 7),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 0, 10),
                ItemFactory.CreateItem("Conjured Mana Cake", 3, 6)

            };

            itemList.ForEach(item => System.Console.WriteLine($"Item: {item.GetType().Name}, \tName: {item.Name}, \tSellIn: {item.SellIn}, \tQuality: {item.Quality}"));

            itemList.ForEach(item => item.UpdateItem());
            System.Console.WriteLine("--- Items Updated ---");

            itemList.ForEach(item => System.Console.WriteLine($"Item: {item.GetType().Name}, \tName: {item.Name}, \tSellIn: {item.SellIn}, \tQuality: {item.Quality}"));


            System.Console.ReadKey();

        }
    }
}
