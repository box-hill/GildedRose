using GildedRose.Console;
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
            UpdatableItem item = new UpdatableItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            item.UpdateItem();
            Assert.Equal(19, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void NormalItem_Should_Decrease_Quality_By_2_When_SellIn_Is_Past()
        {
            UpdatableItem item = new UpdatableItem { Name = "Just A Normal Item", SellIn = 1, Quality = 6 };
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
            UpdatableItem item = new UpdatableItem { Name = "Aged Brie", SellIn = 2, Quality = 0 };
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
            UpdatableItem item = new UpdatableItem { Name = "Aged Brie", SellIn = 3, Quality = 48 };
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
            UpdatableItem item = new UpdatableItem { Name = "Aged Brie", SellIn = -1, Quality = 47 };
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
            UpdatableItem item = new UpdatableItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            item.UpdateItem();
            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.UpdateItem();
            Assert.Equal(80, item.Quality);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Should_Increase_Quality_By_2_When_SellIn_Approaching()
        {
            UpdatableItem item = new UpdatableItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
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
            UpdatableItem item = new UpdatableItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
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
            UpdatableItem item = new UpdatableItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 23 };
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
            UpdatableItem item = new UpdatableItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 };
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void BackstagePasses_Quality_Should_Not_Exceed_50_When_Approaching_SellIn()
        {
            UpdatableItem item = new UpdatableItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 48 };
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
            UpdatableItem item = new UpdatableItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 49 };
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(8, item.SellIn);
        }

        [Fact]
        public void ConguredItems_Should_Decrease_Quality_By_2()
        {
            UpdatableItem item = new UpdatableItem { Name = "Conjured Mana Cake", SellIn = 5, Quality = 30 };
            item.UpdateItem();
            Assert.Equal(28, item.Quality);
            Assert.Equal(4, item.SellIn);
        }

        [Fact]
        public void ConguredItems_Should_Decrease_Quality_By_4_When_Past_SellIn()
        {
            UpdatableItem item = new UpdatableItem { Name = "Conjured Mana Cake", SellIn = 0, Quality = 30 };
            item.UpdateItem();
            Assert.Equal(26, item.Quality);
            Assert.Equal(-1, item.SellIn);

            item.UpdateItem();
            Assert.Equal(22, item.Quality);
            Assert.Equal(-2, item.SellIn);
        }

        [Fact]
        public void ConguredItems_Quality_Should_Not_Be_Negative()
        {
            UpdatableItem item = new UpdatableItem { Name = "Conjured Mana Cake", SellIn = 1, Quality = 1 };
            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(0, item.SellIn);

            item.UpdateItem();
            Assert.Equal(0, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }
    }
}