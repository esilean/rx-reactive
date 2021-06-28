using System;
using System.Reactive.Linq;
using ReactiveRx.Sequences.Extensions;

namespace ReactiveRx.Sequences.SeqGenerators
{
    public class SequenceGenerator
    {
        public SequenceGenerator()
        {
            var tenToTwenty = Observable.Range(10, 11);
            tenToTwenty.Inspect("tenToTwenty");

            var generated = Observable.Generate(
                1,
                value => value < 15,
                value => value + 2,
                value => $"[{value}]"                
            );

            generated.Inspect("generated");

            // var interval =Observable.Interval(TimeSpan.FromSeconds(1));
            // using (interval.Inspect("interval"))
            // {
            //     Console.ReadLine();
            // }

            var timerObs = Observable.Timer(TimeSpan.FromSeconds(4));
            timerObs.Inspect("timerObs");
            Console.ReadLine();


        }
    }
}