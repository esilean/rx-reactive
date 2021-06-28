using ReactiveRx.Obs.Extensions;
using System;
using System.Reactive.Subjects;

namespace ReactiveRx.Obs.Subject
{

    public class SubjectProgramV3
    {
        public SubjectProgramV3()
        {
            var market = new Subject<float>(); // observable
            var marketConsumer = new Subject<float>(); //observer market

            market.Subscribe(marketConsumer);

            ((IObservable<float>)marketConsumer).Subscribe(
                x => Console.WriteLine($"has generated value {x}"),
                ex => Console.WriteLine($"has generaed exc {ex.Message}"),
                () => Console.WriteLine($"has been completed"));

            marketConsumer.Inspect("market consumer");

            market.OnNext(1, 2, 3, 4);
            market.OnCompleted();
        }
    }
}
