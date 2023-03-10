namespace VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account
{
    public record Email
    {
        //variables
        public string PersonalMail { get; init; }
        public string InstitutionalMail { get; init; }
        //constructor
        internal Email(string personalMail, string institutionalMail)
        {
            PersonalMail = personalMail;
            InstitutionalMail = institutionalMail;
        }
        //create method
        public static Email Create(string personalMail, string institutionalMail)
        {
            Validate(personalMail, institutionalMail);
            return new Email(personalMail, institutionalMail);
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
