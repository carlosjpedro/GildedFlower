using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class BackstagePassTests
    {
        [Fact]
        public void PassIncreasesQuality()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 15, Quality = 20}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(21, items[0].Quality);
        }
        
        [Fact]
        public void PassIncreasesQualityByDoubleWhenSellInIsTen()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 10, Quality = 36}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(38, items[0].Quality);
        }
        
        [Fact]
        public void PassIncreasesQualityByDoubleWhenSellInBellowTen()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 8, Quality = 37}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(39, items[0].Quality);
        }

        [Fact] public void PassIncreasesQualityByTripleWhenSellInIsFive()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 5, Quality = 42}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(45, items[0].Quality);
        }
        
        [Fact] public void PassIncreasesQualityByTripleWhenSellInBellowFive()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 3, Quality = 43}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(46, items[0].Quality);
        }
        
        [Fact] public void QualityDoesNotIncreaseOverMax()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 3, Quality = 50}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }
        
        [Fact] public void QualityDropsToZeroWhenSellInIsZero()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = 0, Quality = 50}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }        
        
        [Fact] public void QualityDropsToZeroWhenSellInIsBellowZero()
        {
            var items = new List<Item> {new Item {Name = BackstagePassDefaults.Name, SellIn = -13, Quality = 50}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }           
    }
}