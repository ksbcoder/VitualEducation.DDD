namespace VirtualEducation.DDD.Domain.Commons
{
    //NOT USE. Only for example
    public class Identity
    {
        public Guid Uuid { get; set; }

        public Identity(Guid uuid)
        {
            if (uuid == Guid.Empty)
                throw new ArgumentException("Id cannot be empty");
            this.Uuid = uuid;
        }
    }
}