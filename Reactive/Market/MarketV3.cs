using System.ComponentModel;

namespace Reactive.Market
{
    public class MarketV3
    {
        public BindingList<float> Prices = new BindingList<float>();

        public void AddPrice(float price)
        {
            Prices.Add(price);
        }
    }
}