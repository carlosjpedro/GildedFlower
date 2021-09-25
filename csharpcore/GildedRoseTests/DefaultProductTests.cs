using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class DefaultProductTests
    {
        [Fact]
        public void ItemDegrades()
        {
            var items = new List<Item> { new Item { Name = "ItemA", SellIn = 30, Quality = 45 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(44, items[0].Quality);        
        }

        [Fact]
        public void ItemDegradationDoublesWenSellByIsZero()
        {
            var items = new List<Item> { new Item { Name = "ItemA", SellIn = 0, Quality = 32 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(30, items[0].Quality);     
        }
        
        [Fact]
        public void ItemDegradationDoublesWenSellByIsBellowZero()
        {
            var items = new List<Item> { new Item { Name = "ItemA", SellIn = -10, Quality = 27 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(25, items[0].Quality);     
        }

                
        [Fact]
        public void ItemDoesNotDegradeWhenQualityIsMinimum()
        {
            var items = new List<Item> { new Item { Name = "ItemA", SellIn = 0, Quality = GildedRose.MinQuality } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);     
        }
                
        [Fact]
        public void ItemQualityDoesNotChangeIfQualityIsBellowZero()
        {
            var items = new List<Item> { new Item { Name = "ItemA", SellIn = -5, Quality = -10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(-10, items[0].Quality);     
        }
    }
}
