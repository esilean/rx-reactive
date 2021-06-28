using System;
using System.Reactive.Subjects;

namespace ReactiveRx.Obs.Subject
{
    public class SubjectProgram : IObserver<float>
    {
        public SubjectProgram()
        {
            var market = new Subject<float>();
            market.Subscribe(this);
            market.OnNext(1.24f);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public void OnNext(float value)
        {
            Console.WriteLine($"Market value: {value}");
        }
    }
}
