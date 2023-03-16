using VirtualEducation.DDD.Domain.Classroom.Commands.Courses;

namespace VirtualEducation.DDD.Tests.Builders.Classroom
{
    public class AddCourseCommandBuilder
    {
        private string _classroomId;
        private string _courseName;
        private string _courseDescription;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private int _duration;

        public AddCourseCommandBuilder WithClassroomId(string classroomId)
        {
            _classroomId = classroomId;
            return this;
        }

        public AddCourseCommandBuilder WithCourseName(string courseName)
        {
            _courseName = courseName;
            return this;
        }

        public AddCourseCommandBuilder WithCourseDescription(string courseDetail)
        {
            _courseDescription = courseDetail;
            return this;
        }

        public AddCourseCommandBuilder WithDateStart(DateTime dateStart)
        {
            _dateStart = dateStart;
            return this;
        }

        public AddCourseCommandBuilder WithDateEnd(DateTime dateEnd)
        {
            _dateEnd = dateEnd;
            return this;
        }

        public AddCourseCommandBuilder WithDuration(int duration)
        {
            _duration = duration;
            return this;
        }

        public AddCoursesCommand Build()
        {
            return new AddCoursesCommand(_classroomId, _courseName, _courseDescription, _dateStart, _dateEnd, _duration);
        }
    }
}
