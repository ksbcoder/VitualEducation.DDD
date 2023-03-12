namespace VirtualEducation.DDD.Domain.Commons
{
    public class ChangeEventSuscriber
    {

        private List<DomainEvent> Changes = new List<DomainEvent>();

        public List<DomainEvent> GetChanges() => Changes;

        public void AppendChange(DomainEvent domainEvent)
        {
            this.Changes.Add(domainEvent);
        }
    }
}
