using System.ComponentModel;
using Reactive.Market;

namespace Reactive
{
    class Program
    {
        static void Main(string[] args)
        {
            MarketV1();
            MarketV2();
            MarketV3();
        }

        static void MarketV1()
        {
            System.Console.WriteLine("Starting MarketV1...");
            var market = new MarketV1();
            market.PropertyChanged += (sender, eventArgs) =>
            {
                if(eventArgs.PropertyName == "Volatility")
                {
                    float price = ((MarketV1)sender).Volatility;
                    System.Console.WriteLine($"Rx1: We got a price of {price}");
                }
            };

            market.Volatility = 11;

            System.Console.WriteLine("Ending MarketV1...");
            System.Console.WriteLine("..................");
        }
        
        static void MarketV2()
        {
            System.Console.WriteLine("Starting MarketV2...");
            var market = new MarketV2();
            market.PriceAdded += (sender, f) =>
            {
                System.Console.WriteLine($"Rx2: We got a price of {f}");
            };
            market.AddPrice(22);

            System.Console.WriteLine("Ending MarketV2...");
            System.Console.WriteLine("..................");
        }
    
        static void MarketV3()
        {
            System.Console.WriteLine("Starting MarketV3...");
            var market = new MarketV3();
            market.Prices.ListChanged += (sender, eventArgs) =>
            {
                if(eventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    float price = ((BindingList<float>)sender)[eventArgs.NewIndex];
                    System.Console.WriteLine($"Rx3: We got a price of {price}");
                }
                
            };
            market.AddPrice(33);

            System.Console.WriteLine("Ending MarketV3...");
            System.Console.WriteLine("..................");
        }
    }
}
