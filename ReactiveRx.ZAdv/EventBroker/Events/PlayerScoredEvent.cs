namespace ReactiveRx.ZAdv.EventBroker.Events
{
    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }
}
