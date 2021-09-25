using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const int MaxQuality = 50;
        public const int MinQuality = 0;

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.SellIn -= 1;

                UpdateItemQuantity(item);
            }
        }

        private static void UpdateItemQuantity(Item item)
        {
            switch (item.Name)
            {
                case SulfurasProductDefaults.Name:
                    break;
                case ConjuredDefaults.Name:
                    item.Quality = item.SellIn switch
                    {
                        < 0 => item.Quality = DecreseQuality(item, ConjuredDefaults.PastSellInDateConjuredDegradationRatio),
                        _ => item.Quality = DecreseQuality(item, ConjuredDefaults.ConjuredDegradationRatio)
                    };
                    break;
                case BackstagePassDefaults.Name:
                    item.Quality = item.SellIn switch
                    {
                        < 0 => MinQuality,
                        < 5 => IncreaseQuality(item, BackstagePassDefaults.PassUltraValueIncrease),
                        < 10 => IncreaseQuality(item, BackstagePassDefaults.PassExtraValueIncrease),
                        _ => IncreaseQuality(item, BackstagePassDefaults.PassDefaultValueIncrease),
                    };
                    break;
                case AgedBrieDefaults.Name:
                    item.Quality = item.SellIn switch
                    {
                        < 0 => item.Quality = IncreaseQuality(item, AgedBrieDefaults.AgedBrieIncreaseAfterSellInDate),
                        _ => item.Quality = IncreaseQuality(item, AgedBrieDefaults.AgedBrieDefaultIncrease)
                    };
                    break;
                default:
                    item.Quality = item.SellIn switch
                    {
                        < 0 => item.Quality = DecreseQuality(item, CommonProductDefaults.PastSellInDateDefaultDegradationRation),
                        _ => item.Quality = DecreseQuality(item, CommonProductDefaults.DefaultDegradationRatio)
                    };
                    break;
            }
        }

        private static int IncreaseQuality(Item item, int value) =>
            Math.Min(item.Quality + value, MaxQuality);

        private static int DecreseQuality(Item item, int value ) =>
            item.Quality <= MinQuality ? item.Quality : Math.Max(item.Quality - value, 0);
    }
}