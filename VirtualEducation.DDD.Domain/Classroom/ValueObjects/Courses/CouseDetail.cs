﻿namespace VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses
{
    public class CourseDetail
    {
        //variables
        public string CourseName { get; init; }
        public string CourseDescription { get; init; }
        public DateTime DateStart { get; init; }
        public DateTime DateEnd { get; init; }
        public int Duration { get; init; }


        //constructor
        public CourseDetail(string courseName, string courseDescription, DateTime dateStart, DateTime dateEnd, int duration)
        {
            CourseName = courseName;
            CourseDescription = courseDescription;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Duration = duration;
        }


        //create method
        public static CourseDetail Create(string courseName, string courseDescription, DateTime dateStart, DateTime dateEnd, int duration)
        {
            Validate(courseName, courseDescription, dateStart, dateEnd, duration);
            return new CourseDetail(courseName, courseDescription, dateStart, dateEnd, duration);
        }
        //validate method
        public static void Validate(string courseName, string courseDescription, DateTime dateStart, DateTime dateEnd, int duration)
        {
            if (courseName.Equals(null))
            {
                throw new ArgumentNullException("Course name cannot be null");
            }
            if (courseDescription.Equals(null))
            {
                throw new ArgumentNullException("Course description cannot be null");
            }
            if (dateStart.Equals(null))
            {
                throw new ArgumentNullException("Date start cannot be null");
            }
            if (dateEnd.Equals(null))
            {
                throw new ArgumentNullException("Date end cannot be null");
            }
            if (duration.Equals(null))
            {
                throw new ArgumentNullException("Duration cannot be null");
            }
            if (dateStart > dateEnd)
            {
                throw new ArgumentException("Date start cannot be greater than date end");
            }
            if (duration < 0)
            {
                throw new ArgumentException("Duration cannot be less than 0");
            }
        }
    }
}
