using System.Reactive.Linq;
using ReactiveRx.Sequences.Extensions;

namespace ReactiveRx.Sequences.Filtering
{
    public class FilteringObs
    {
        public FilteringObs()
        {
            // Observable.Range(0, 100)
            //     .Where(x => x % 9 == 0)
            //     .Inspect("where");

            var values = Observable.Range(-10, 11);
            values
                .Select(x => x*x)
                .Distinct()
                .Inspect("select distinct");
        }
    }
}