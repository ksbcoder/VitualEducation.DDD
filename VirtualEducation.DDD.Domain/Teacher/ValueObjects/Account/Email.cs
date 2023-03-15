namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public class TeacherEmail
    {
        //variables
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }


        //constructor
        public TeacherEmail(string personalMail, string institutionalMail)
        {
            PersonalMail = personalMail;
            InstitutionalMail = institutionalMail;
        }


        //create method
        public static TeacherEmail Create(string personalMail, string institutionalMail)
        {
            Validate(personalMail, institutionalMail);
            return new TeacherEmail(personalMail, institutionalMail);
        }
        //validate method
        public static void Validate(string personalMail, string institutionalMail)
        {
            if (personalMail.Equals(null))
            {
                throw new ArgumentNullException("Personal mail cannot be null");
            }
            if (institutionalMail.Equals(null))
            {
                throw new ArgumentNullException("Institutional mail cannot be null");
            }
        }
    }
}
