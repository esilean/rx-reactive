using System;
using System.Collections.Generic;

namespace ReactiveRx.Market
{
    public class MarketV2
    {
        private List<float> prices = new List<float>();

        public void AddPrice(float price)
        {
            prices.Add(price);
            PriceAdded?.Invoke(this, price);
        }

        public event EventHandler<float> PriceAdded;
    }
}