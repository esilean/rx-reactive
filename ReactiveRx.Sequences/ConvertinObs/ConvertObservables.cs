using System;
using System.Reactive.Linq;
using System.Threading;
using ReactiveRx.Sequences.Extensions;

namespace ReactiveRx.Sequences.ConvertinObs
{
    public class ConvertObservables
    {
        public ConvertObservables()
        {
            var start = Observable.Start(() => {
                System.Console.WriteLine("Starting...");

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(200);
                    System.Console.Write(".");
                }
            });

            start.Inspect("start");
            Console.ReadKey();
        }
    }
}