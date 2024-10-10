using GildedRose.Console;
using GildedRose.Console.Items;
using NuGet.Frameworks;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void NormalItem_Should_Decrease_SellIn_And_Quality()
        {
            UpdatableItem item = ItemFactory.CreateItem("+5 Dexterity Vest", 10, 20);
            item.UpdateItem();
            Assert.Equal(19, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void NormalItem_Should_Decrease_Quality_By_2_When_SellIn_Is_Past()
        {
            UpdatableItem item = ItemFactory.CreateItem("Just A Normal Item", 1, 6);
            item.UpdateItem();
            Assert.Equal(5, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.UpdateItem();
            Assert.Equal(3, item.Quality);
            Assert.Equal(-1, item.SellIn);

            item.UpdateItem();
            Assert.Equal(1, item.Quality);
            Assert.Equal(-2, item.SellIn);

            // Quality cannot be negative
            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-3, item.SellIn);

            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-4, item.SellIn);
        }

        [Fact]
        public void AgedBrie_Should_Increase_Quality_And_Decrease_SellIn()
        {
            UpdatableItem item = ItemFactory.CreateItem("Aged Brie", 2, 0);
            item.UpdateItem();
            Assert.Equal(1, item.Quality);
            Assert.Equal(1, item.SellIn);

            item.UpdateItem();
            Assert.Equal(2, item.Quality);
            Assert.Equal(0, item.SellIn);

            // Quality should increase twice as fast once SellIn has past
            item.UpdateItem();
            Assert.Equal(4, item.Quality);
            Assert.Equal(-1, item.SellIn);

            item.UpdateItem();
            Assert.Equal(6, item.Quality);
            Assert.Equal(-2, item.SellIn);
        }

        [Fact]
        public void AgedBrie_Quality_Should_Not_Exceed_50()
        {
            UpdatableItem item = ItemFactory.CreateItem("Aged Brie", 3, 48);
            item.UpdateItem();
            Assert.Equal(49, item.Quality);
            Assert.Equal(2, item.SellIn);

            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(1, item.SellIn);

            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void AgedBrie_Quality_Should_Not_Exceed_50_When_Past_SellIn()
        {
            UpdatableItem item = ItemFactory.CreateItem("Aged Brie", -1, 47);
            item.UpdateItem();
            Assert.Equal(49, item.Quality);
            Assert.Equal(-2, item.SellIn);

            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(-3, item.SellIn);

            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(-4, item.SellIn);
        }

        [Fact]
        public void Sulfuras_No_Change_To_Quality_And_SellIn()
        {
            UpdatableItem item = ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80);
            item.UpdateItem();
            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.UpdateItem();
            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Should_Increase_Quality()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 45);
            item.UpdateItem();
            Assert.Equal(46, item.Quality);
            Assert.Equal(14, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Should_Increase_Quality_By_2_When_SellIn_Approaching()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 20);
            item.UpdateItem();
            Assert.Equal(22, item.Quality);
            Assert.Equal(9, item.SellIn);

            item.UpdateItem();
            Assert.Equal(24, item.Quality);
            Assert.Equal(8, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Should_Increase_Quality_By_3_When_Close_To_SellIn()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 10);
            item.UpdateItem();
            Assert.Equal(13, item.Quality);
            Assert.Equal(4, item.SellIn);

            item.UpdateItem();
            Assert.Equal(16, item.Quality);
            Assert.Equal(3, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Should_Drop_Quality_After_Concert()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 1, 23);
            item.UpdateItem();
            Assert.Equal(26, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Quality_Should_Not_Exceed_50()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 50);
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Quality_Should_Not_Exceed_50_When_Approaching_SellIn()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 3, 48);
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(2, item.SellIn);

            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(1, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Quality_Should_Not_Exceed_50_When_SellIn_Closing()
        {
            UpdatableItem item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 9, 49);
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(8, item.SellIn);
        }

        [Fact]
        public void ConjuredItems_Should_Decrease_Quality_By_2()
        {
            UpdatableItem item = ItemFactory.CreateItem("Conjured Mana Cake", 5, 30);
            item.UpdateItem();
            Assert.Equal(28, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void ConjuredItems_Should_Decrease_Quality_By_4_When_Past_SellIn()
        {
            UpdatableItem item = ItemFactory.CreateItem("Conjured Mana Cake", 0, 30);
            item.UpdateItem();
            Assert.Equal(26, item.Quality);
            Assert.Equal(-1, item.SellIn);

            item.UpdateItem();
            Assert.Equal(22, item.Quality);
            Assert.Equal(-2, item.SellIn);
        }

        [Fact]
        public void ConjuredItems_Quality_Should_Not_Be_Negative()
        {
            UpdatableItem item = ItemFactory.CreateItem("Conjured Mana Cake", 1, 1);
            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void Factory_Should_Create_Correct_Item_Type()
        {
            UpdatableItem item = ItemFactory.CreateItem("Conjured Mana Cake", 1, 1);
            Assert.Equal("Conjured", item.GetType().Name);

            item = ItemFactory.CreateItem("+5 Dexterity Vest", 10, 20);
            Assert.Equal("UpdatableItem", item.GetType().Name);

            item = ItemFactory.CreateItem("Aged Brie", 2, 0);
            Assert.Equal("AgedBrie", item.GetType().Name);

            item = ItemFactory.CreateItem("Elixir of the Mongoose", 5, 7);
            Assert.Equal("UpdatableItem", item.GetType().Name);

            item = ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80);
            Assert.Equal("Sulfuras", item.GetType().Name);

            item = ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            Assert.Equal("BackstagePass", item.GetType().Name);

            item = ItemFactory.CreateItem("Conjured Mana Cake", 1, 1);
            Assert.Equal("Conjured", item.GetType().Name);
        }

        [Fact]
        public void Factory_Should_Create_New_Instance_Every_Time()
        {
            List<UpdatableItem> itemList = new List<UpdatableItem>
            {
                ItemFactory.CreateItem("Conjured Mana Cake", 0, 10),
                ItemFactory.CreateItem("Conjured Mana Cake", 5, 30),
                ItemFactory.CreateItem("Normal Item", 7, 20),
                ItemFactory.CreateItem("Not Sulfuras", -3, 7)
            };

            itemList.ForEach(item => item.UpdateItem());
            Assert.Equal(-1, itemList[0].SellIn);
            Assert.Equal(4, itemList[1].SellIn);
            Assert.Equal(6, itemList[2].SellIn);
            Assert.Equal(-4, itemList[3].SellIn);

            Assert.Equal(6, itemList[0].Quality);
            Assert.Equal(28, itemList[1].Quality);
            Assert.Equal(19, itemList[2].Quality);
            Assert.Equal(5, itemList[3].Quality);
        }
    }
}