using ReactiveRx.ZAdv.EventBroker.Events;
using System;
using System.Reactive.Linq;

namespace ReactiveRx.ZAdv.EventBroker.Entities
{
    public class FootballPlayer : Actor
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; }

        public void ScoreGoal()
        {
            GoalsScored++;
            _broker.Publish(new PlayerScoredEvent { Name = Name, GoalsScored = GoalsScored });
        }

        public void AssaultReferee(string reason)
        {
            _broker.Publish(new PlayerSentOffEvent { Name = Name, Reason = reason });
        }

        public FootballPlayer(EventBroker broker, string name) : base(broker)
        {
            Name = name;

            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(pe =>
                {
                    Console.WriteLine($"{Name}: Well done! It's your {pe.GoalsScored} goal {pe.Name}.");
                });
        }
    }
}
