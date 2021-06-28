using System;

namespace ReactiveRx.Sequences.Extensions
{
public static class ExtensionMethods
    {
        public static IDisposable Inspect<T>(this IObservable<T> self, string name)
        {
            return self.Subscribe(
                x => Console.WriteLine($"{name} has generated value {x}"),
                ex => Console.WriteLine($"{name} has generaed exc {ex.Message}"),
                () => Console.WriteLine($"{name} has been completed"));
        }

        public static IObserver<T> OnNext<T>(this IObserver<T> self,
            params T[] args)
        {
            foreach (var arg in args)
            {
                self.OnNext(arg);
            }

            return self;
        }
    }
}