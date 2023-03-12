namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public class TeacherPermissions
    {
        //variables
        public string Role { get; init; }


        //constructor
        public TeacherPermissions(string role)
        {
            this.Role = role;
        }


        //create method
        public static TeacherPermissions Create(string role)
        {
            Validate(role);
            return new TeacherPermissions(role);
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
