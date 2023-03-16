namespace VirtualEducation.DDD.Domain.Teacher.Commands.Account
{
    public class TeacherUpdateEmailCommand
    {
        public string TeacherId { get; set; }
        public string PersonalMail { get; init; }

        public TeacherUpdateEmailCommand(string teacherId, string personalMail)
        {
            TeacherId = teacherId;
            PersonalMail = personalMail;
        }
    }
}
