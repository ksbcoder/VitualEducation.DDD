namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom
{
    public class Preferences
    {
        //variables
        public bool Notifications { get; init; }


        //constructor
        public Preferences(bool notifications)
        {
            Notifications = notifications;
        }


        //create method
        public static Preferences Create(bool notifications)
        {
            Validate(notifications);
            return new Preferences(notifications);
        }
        //validate method
        public static void Validate(bool notifications)
        {
            if (notifications.Equals(null))
            {
                throw new ArgumentNullException("Notifications cannot be null");
            }
        }
    }
}
