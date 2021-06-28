using ReactiveRx.Obs.Extensions;
using ReactiveRx.Obs.ZObservable;

namespace ReactiveRx.Obs
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new MarketObs();
            var sub1 = market.Inspect("market 1");
            var sub2 = market.Inspect("market 2");

            market.Publish(123f);
            sub1.Dispose();
            sub2.Dispose();

            System.Console.ReadKey();
        }
    }
}
