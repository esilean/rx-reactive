using System;
using System.Reactive.Linq;
using System.Timers;
using ReactiveRx.Sequences.Extensions;

namespace ReactiveRx.Sequences.CreateObs
{
    public class TimerObs
    {
        public TimerObs()
        {
            var o = Observable.Create<string>(o =>
            {
                var timer = new Timer(1000);
                timer.Elapsed += (sender, e) => 
                        o.OnNext($"tick {e.SignalTime}");
                timer.Elapsed += TimerOnElapsed;

                timer.Start();
                return () => {
                    timer.Elapsed -= TimerOnElapsed;
                    timer.Dispose();
                };
            });

            var sub = o.Inspect("timer");
        
            Console.ReadLine();
            sub.Dispose();
            Console.ReadLine();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            System.Console.WriteLine($"tock {e.SignalTime}");
        }
    }
}