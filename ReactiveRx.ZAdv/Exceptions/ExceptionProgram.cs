using ReactiveRx.ZAdv.Extensions;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveRx.ZAdv.Exceptions
{
    public class ExceptionProgram
    {
        public ExceptionProgram()
        {
            var subj = new Subject<int>();
            var fallback = Observable.Range(1, 3);

            subj
                .Catch<int, ArgumentException>(ex => Observable.Return(111))
                .Catch(fallback)
                .Inspect("subg");

            subj.OnNext(23);
            subj.OnError(new ArgumentException("ooops"));
        }
    }
}
