using ReactiveRx.ZAdv.EventBroker.Events;
using System;
using System.Reactive.Linq;

namespace ReactiveRx.ZAdv.EventBroker.Entities
{
    public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
                .Subscribe(pe =>
                {
                    if (pe.GoalsScored > 2)
                        Console.WriteLine($"Coach: Well done, {pe.Name}!");
                });

            broker.OfType<PlayerSentOffEvent>()
                .Subscribe(pe =>
                {
                    if (pe.Reason == "violence")
                        Console.WriteLine($"Coach: WTF {pe.Name}!");
                });
        }
    }
}
