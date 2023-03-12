namespace VirtualEducation.DDD.Domain.Commons
{
    public class Entity<T> where T : Identity
    {
        protected T entityId;

        public Entity(T entityId)
        {
            this.entityId = entityId;
        }

        public T Identity() => entityId;
    }
}