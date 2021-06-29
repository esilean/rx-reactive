using ReactiveRx.ZAdv.EventBroker.Events;
using System;
using System.Reactive.Subjects;

namespace ReactiveRx.ZAdv.EventBroker
{
    public class EventBroker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent @event)
        {
            subscriptions.OnNext(@event);
        }
    }
}
