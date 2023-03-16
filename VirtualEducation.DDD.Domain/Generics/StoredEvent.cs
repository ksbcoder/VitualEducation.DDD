using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualEducation.DDD.Domain.Generics
{
    public class StoredEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoredId { get; set; }
        public string StoredName { get; set; }
        public string AggregateId { get; set; }
        public string EventBody { get; set; }

        public StoredEvent(int storedId, string storedName, string aggregateId, string eventBody)
        {
            StoredId = storedId;
            StoredName = storedName;
            AggregateId = aggregateId;
            EventBody = eventBody;
        }

        public StoredEvent() { }
    }
}