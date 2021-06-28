using ReactiveRx.Obs.Extensions;
using System;
using System.Reactive.Subjects;
using System.Threading;

namespace ReactiveRx.Obs.SubjectReplay
{

    public class SubjectReplayProgramV1
    {
        public SubjectReplayProgramV1()
        {
            var timeWindow = TimeSpan.FromMilliseconds(500);
            var market = new ReplaySubject<float>(timeWindow); // observable
            //var market = new ReplaySubject<float>(1); // observable
            var marketConsumer = new Subject<float>(); //observer market

            marketConsumer.Inspect("market consumer");

            market.OnNext(1);
            Thread.Sleep(200);
            market.OnNext(2);
            Thread.Sleep(200);
            market.OnNext(3);
            Thread.Sleep(200);

            market.Subscribe(marketConsumer);

            market.OnCompleted();
        }
    }
}
