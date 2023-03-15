using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class PersonalDataAdded : DomainEvent
    {
        public StudentPersonalData PersonalData { get; set; }

        public PersonalDataAdded(StudentPersonalData personalData) : base("student.personaldata.added")
        {
            PersonalData = personalData;
        }
    }
}
