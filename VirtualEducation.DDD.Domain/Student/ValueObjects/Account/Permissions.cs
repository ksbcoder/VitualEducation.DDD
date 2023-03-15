namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public class StudentPermissions
    {
        //variables
        public string Role { get; init; }


        //constructor
        public StudentPermissions(string role)
        {
            this.Role = role;
        }

        //create method
        public static StudentPermissions Create(string role)
        {
            Validate(role);
            return new StudentPermissions(role);
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
