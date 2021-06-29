using ReactiveRx.ZAdv.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveRx.ZAdv.Messages.Services
{
    public class MessageEventHandler<T> : IMessageEventHandler<T>, IDisposable
    {

        private readonly Subject<T> _subject;
        private readonly Dictionary<string, IDisposable> _subscribers;

        public MessageEventHandler()
        {
            _subject = new Subject<T>();
            _subscribers = new Dictionary<string, IDisposable>();
        }

        public void Publish(T @event)
        {
            _subject.OnNext(@event);
        }

        public void Subscribe(string subscriberName, Action<T> action)
        {
            if (!_subscribers.ContainsKey(subscriberName))
            {
                _subscribers.Add(subscriberName, _subject.Subscribe(action));
            }
        }

        public void Subscribe(string subscriberName, Func<T, bool> predicate, Action<T> action)
        {
            if (!_subscribers.ContainsKey(subscriberName))
            {
                _subscribers.Add(subscriberName, _subject.Where(predicate).Subscribe(action));
            }
        }

        public void Dispose()
        {
            if (_subject != null)
            {
                _subject.Dispose();
            }

            foreach (var subscriber in _subscribers)
            {
                subscriber.Value.Dispose();
            }
        }
    }
}
