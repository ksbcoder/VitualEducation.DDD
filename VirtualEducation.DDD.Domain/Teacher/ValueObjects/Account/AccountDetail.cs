namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public record AccountDetail
    {
        //variables
        public string Username { get; init; }
        public DateTime CreatedAt { get; init; }
        //constructor
        internal AccountDetail(string username, DateTime createdAt)
        {
            Username = username;
            CreatedAt = createdAt;
        }
        //create method
        public static AccountDetail Create(string username, DateTime createdAt)
        {
            Validate(username, createdAt);
            return new AccountDetail(username, createdAt);
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
