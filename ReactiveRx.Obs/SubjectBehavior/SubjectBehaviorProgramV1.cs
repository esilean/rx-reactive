using ReactiveRx.Obs.Extensions;
using System.Reactive.Subjects;

namespace ReactiveRx.Obs.SubjectBehavior
{

    public class SubjectBehaviorProgramV1
    {
        public SubjectBehaviorProgramV1()
        {
            var sensonReading = new BehaviorSubject<double>(-1.0);
            sensonReading.Inspect("sensor");

            sensonReading.OnNext(-.99);
            sensonReading.OnCompleted();

            sensonReading.OnNext(-.98);
        }
    }
}
