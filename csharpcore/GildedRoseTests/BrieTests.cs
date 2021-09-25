using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class BrieTests
    {
        [Fact]
        public void BrieIncreasesQualityOverTime()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name =AgedBrieDefaults.Name, SellIn = 15, Quality = 20
                }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void BrieQualityIsNeverOverMaxValue()
        {
            var items = new List<Item>
            {
                new Item {Name =AgedBrieDefaults.Name, SellIn = 15, Quality = GildedRose.MaxQuality}
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void BrieIncreasesQualityByDoubleWhenSellInIsZero()
        {
            var items = new List<Item>
            {
                new Item {Name =AgedBrieDefaults.Name, SellIn = 0, Quality = 2}
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(4, items[0].Quality);
        }
        
        [Fact]
        public void BrieIncreasesQualityByDoubleWhenSellInIsBellowZero()
        {
            var items = new List<Item>
            {
                new Item {Name = AgedBrieDefaults.Name, SellIn = -5, Quality = 23}
            };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(25, items[0].Quality);
        }
    }
}