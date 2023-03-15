using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class PersonalDataAdded : DomainEvent
    {
        public TeacherPersonalData PersonalData { get; set; }

        public PersonalDataAdded(TeacherPersonalData personalData) : base("teacher.personaldata.added")
        {
            PersonalData = personalData;
        }
    }
}
