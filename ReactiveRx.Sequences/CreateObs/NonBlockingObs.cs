using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using ReactiveRx.Sequences.Extensions;

namespace ReactiveRx.Sequences.CreateObs
{
    public class NonBlockingObs
    {

        private static IObservable<string> Blocking()
        {
            var subj = new ReplaySubject<string>();
            subj.OnNext("foo", "bar");
            subj.OnCompleted();

            Thread.Sleep(3000);
            return subj;
        }

        private static IObservable<string> NonBlocking()
        {
            return Observable.Create<string>(o => {
               o.OnNext("foo", "bar");
               o.OnCompleted();
               Thread.Sleep(3000);

               return Disposable.Empty;
            });
        }

        public NonBlockingObs()
        {
            Blocking().Inspect("blocking");
            NonBlocking().Inspect("non blocking");
        }
    }
}