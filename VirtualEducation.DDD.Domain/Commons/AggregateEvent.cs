namespace VirtualEducation.DDD.Domain.Commons
{
    public abstract class AggregateEvent
    {

        private ChangeEventSuscriber ChangeEventSuscriber = new();

        public List<DomainEvent> GetUncommittedChanges() => ChangeEventSuscriber.GetChanges().ToList();

        public void AppendChange(DomainEvent evento)
        {
            string nameClass = evento.GetType().Name;
            evento.SetAggregate(nameClass);
            //the follow line is executed in the use case save event (Methods SaveEvents)
            //evento.SetAggregateId();
            ChangeEventSuscriber.AppendChange(evento);
        }
    }
}