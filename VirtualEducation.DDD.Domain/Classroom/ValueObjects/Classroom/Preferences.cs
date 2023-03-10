namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom
{
    public record Preferences
    {
        //variables
        public string Notifications { get; init; }
        //constructor
        internal Preferences(string notifications)
        {
            Notifications = notifications;
        }
        //create method
        public static Preferences Create(string notifications)
        {
            Validate(notifications);
            return new Preferences(notifications);
        }
        //validate method
        public static void Validate(string notifications)
        {
            if (notifications.Equals(null))
            {
                throw new ArgumentNullException("Notifications cannot be null");
            }
        }
    }
}
