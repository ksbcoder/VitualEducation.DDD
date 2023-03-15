namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public class StudentAccountDetail
    {
        //variables
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; }


        //constructor
        public StudentAccountDetail(string username, DateTime createdAt)
        {
            Username = username;
            CreatedAt = createdAt;
        }

        //create method
        public static StudentAccountDetail Create(string username, DateTime createdAt)
        {
            Validate(username, createdAt);
            return new StudentAccountDetail(username, createdAt);
        }
        //validate method
        public static void Validate(string username, DateTime? createdAt)
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
