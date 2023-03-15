namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public class TeacherAccountDetail
    {
        //variables
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; }


        //constructor
        public TeacherAccountDetail(string username, DateTime createdAt)
        {
            Username = username;
            CreatedAt = createdAt;
        }


        //create method
        public static TeacherAccountDetail Create(string username, DateTime createdAt)
        {
            Validate(username, createdAt);
            return new TeacherAccountDetail(username, createdAt);
        }
        //validate method
        public static void Validate(string username, DateTime createdAt)
        {
            if (username.Equals(null))
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            if (createdAt.Equals(null))
            {
                throw new ArgumentNullException("Created date cannot be null");
            }
        }
    }
}
