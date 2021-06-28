using System;
using System.Reactive.Subjects;

namespace ReactiveRx.Obs.Subject
{
    public class SubjectProgramV2
    {
        public SubjectProgramV2()
        {
            var market = new Subject<float>();
            market.Subscribe(
                f => Console.WriteLine($"Market value: {f}"),
                () => Console.WriteLine("Completed"));

            market.OnNext(1.24f);
            market.OnNext(1.25f);
            market.OnCompleted();
            market.OnError(new Exception("Ooops!"));

            market.Dispose();
        }
    }
}
