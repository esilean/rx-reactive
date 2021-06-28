using System;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ReactiveRx.Sequences.Extensions;

namespace ReactiveRx.Sequences.ConvertinTasks
{
    public class ConvertTaskObservables
    {
        public ConvertTaskObservables()
        {
            var t = Task.Factory.StartNew(() => 42);
            var source = t.ToObservable();
            source.Inspect("task");
            Console.ReadKey();
        }
    }
}