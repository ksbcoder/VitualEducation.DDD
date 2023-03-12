using Ardalis.Specification;
using VirtualEducation.DDD.Domain.Generics;

namespace VirtualEducation.DDD.Domain.UseCases.Gateways.Repositories
{
    public interface IStoredEventRepository<T> : IRepositoryBase<T> where T : class
    {
        Task<List<StoredEvent>> GetEventsByAggregateId(string aggregateId);
    }
}
