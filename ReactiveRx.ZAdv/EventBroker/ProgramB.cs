using ReactiveRx.ZAdv.EventBroker.Entities;

namespace ReactiveRx.ZAdv.EventBroker
{
    public class ProgramB
    {
        public ProgramB()
        {
            var broker = new EventBroker();

            new FootballCoach(broker);
            var player1 = new FootballPlayer(broker, "Foo");
            var player2 = new FootballPlayer(broker, "Bar");


            player1.ScoreGoal();
            player1.ScoreGoal();
            player1.ScoreGoal();
            player1.AssaultReferee("violence");

            player2.ScoreGoal();
        }
    }

}
