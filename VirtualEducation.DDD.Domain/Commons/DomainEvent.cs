namespace VirtualEducation.DDD.Domain.Commons
{
    public class DomainEvent
    {

        public string Type;
        private string AggregateId;
        private string Aggregate;
        private decimal VersionType;

        public DomainEvent(string type)
        {
            Type = type;
        }

        public string GetAggregateId() => AggregateId;

        public string GetAggregate() => Aggregate;

        public decimal GetVersionType() => VersionType;

        public void SetAggregateId(string aggregateId) => AggregateId = aggregateId;

        public void SetAggregate(string aggregate) => Aggregate = aggregate;

        public void SetVersionType(decimal versionType) => VersionType = versionType;
    }
}