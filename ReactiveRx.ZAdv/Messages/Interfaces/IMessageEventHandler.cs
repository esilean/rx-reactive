using System;

namespace ReactiveRx.ZAdv.Messages.Interfaces
{
    public interface IMessageEventHandler<T>
    {
        void Publish(T @event);

        void Subscribe(string subscriberName, Action<T> action);

        void Subscribe(string subscriberName, Func<T, bool> predicate, Action<T> action);
    }
}
