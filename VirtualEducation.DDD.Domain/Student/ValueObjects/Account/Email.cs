namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public class StudentEmail
    {
        //variables
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }


        //constructor
        public StudentEmail(string personalMail, string institutionalMail)
        {
            PersonalMail = personalMail;
            InstitutionalMail = institutionalMail;
        }

        //create method
        public static StudentEmail Create(string personalMail, string institutionalMail)
        {
            Validate(personalMail, institutionalMail);
            return new StudentEmail(personalMail, institutionalMail);
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
