namespace VirtualEducation.DDD.Domain.Classroom.Commands.Courses
{
    public class AddCoursesCommand
    {
        public string ClassroomId { get; init; }
        public string CourseName { get; init; }
        public string CourseDescription { get; init; }
        public DateTime DateStart { get; init; }
        public DateTime DateEnd { get; init; }
        public int Duration { get; init; }

        public AddCoursesCommand(string classroomId, string courseName, string courseDescription, DateTime dateStart, DateTime dateEnd, int duration)
        {
            ClassroomId = classroomId;
            CourseName = courseName;
            CourseDescription = courseDescription;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Duration = duration;
        }
    }
}
