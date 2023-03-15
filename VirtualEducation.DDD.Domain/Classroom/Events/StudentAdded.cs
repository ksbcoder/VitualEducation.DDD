using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.Entities;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class StudentAdded :DomainEvent
    {
        public Student.Entities.Student Student { get; init; }
        public StudentAdded(Student.Entities.Student student) : base("classroom.student.added")
        {
            Student = student;
        }
    }
}
