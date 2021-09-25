using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class SulfurasTests
    {
        [Fact]
        public void SulfurasNeverChanges()
        {
            var items = new List<Item> {new Item {Name =SulfurasProductDefaults.Name, SellIn = 15, Quality = GildedRose.MaxQuality}};
            var app = new GildedRose(items);

            for (var i = 0; i < 100; i++)
            {
                app.UpdateQuality();
                Assert.Equal(50, items[0].Quality);
            }
        }
    }
}