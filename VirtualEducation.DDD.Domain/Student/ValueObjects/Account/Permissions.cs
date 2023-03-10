namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public record Permissions
    {
        //variables
        public string Role { get; init; }
        //constructor
        internal Permissions(string role)
        {
            this.Role = role;
        }
        //create method
        public static Permissions Create(string role)
        {
            Validate(role);
            return new Permissions(role);
        }
        //validate method
        public static void Validate(string role)
        {
            if (role.Equals(null))
            {
                throw new ArgumentNullException("Role cannot be null");
            }
        }
    }
}
