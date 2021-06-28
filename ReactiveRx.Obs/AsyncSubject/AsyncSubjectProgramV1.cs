using ReactiveRx.Obs.Extensions;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ReactiveRx.Obs.AsyncSubject
{

    public class AsyncSubjectProgramV1
    {
        public AsyncSubjectProgramV1()
        {
            var senson = new AsyncSubject<double>();
            senson.Inspect("async");

            senson.OnNext(1.0);
            senson.OnNext(2.0);

            senson.OnCompleted();
        }
    }
}
