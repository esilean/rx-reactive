namespace ReactiveRx.ZAdv.EventBroker.Entities
{
    public class Actor
    {
        protected EventBroker _broker;

        public Actor(EventBroker broker)
        {
            _broker = broker;
        }
    }
}
