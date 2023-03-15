namespace VirtualEducation.DDD.Domain.Commons
{
    //NOT USE. Only for example
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