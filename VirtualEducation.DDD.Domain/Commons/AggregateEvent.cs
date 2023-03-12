namespace VirtualEducation.DDD.Domain.Commons
{
    public abstract class AggregateEvent<T> : Entity<T> where T : Identity
    {

        private ChangeEventSuscriber ChangeEventSuscriber = new();

        protected AggregateEvent(T entityId) : base(entityId) { }

        public List<DomainEvent> GetUncommittedChanges() => ChangeEventSuscriber.GetChanges().ToList();

        public void AppendChange(DomainEvent evento)
        {
            string nameClass = evento.GetType().Name;
            evento.SetAggregate(nameClass);
            evento.SetAggregateId(Identity().Uuid.ToString());
            ChangeEventSuscriber.AppendChange(evento);
        }
    }
}