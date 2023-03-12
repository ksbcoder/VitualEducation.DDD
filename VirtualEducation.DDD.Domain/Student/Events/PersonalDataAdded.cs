using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class PersonalDataAdded : DomainEvent
    {
        public PersonalData PersonalData { get; set; }

        public PersonalDataAdded(PersonalData personalData) : base("student.personaldata.added")
        {
            PersonalData = personalData;
        }
    }
}
