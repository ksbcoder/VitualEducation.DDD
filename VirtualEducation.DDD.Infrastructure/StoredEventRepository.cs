using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;

namespace VirtualEducation.DDD.Infrastructure
{
    public class StoredEventRepository<T> : RepositoryBase<T>, IStoredEventRepository<T> where T : class
    {

        private readonly DataBaseContext dataBaseContext;
        public StoredEventRepository(DataBaseContext dbContext) : base(dbContext)
        {
            dataBaseContext = dbContext;
        }

        public async Task<List<StoredEvent>> GetEventsByAggregateId(string aggregateId)
        {
            return dataBaseContext.StoredEvents.Where(evento => evento.AggregateId == aggregateId).ToList();

        }
    }
}
