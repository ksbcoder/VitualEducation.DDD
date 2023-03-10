using Microsoft.EntityFrameworkCore;
using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Teacher.Entities;

namespace VirtualEducation.DDD.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        //student tables
        public DbSet<Student> Students { get; set; }
        public DbSet<AccountStudent> Accounts { get; set; }
        public DbSet<ClassroomRegistrationStudent> ClassroomRegistrations { get; set; }
        //teacher tables
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AccountTeacher> AccountsTeacher { get; set; }
        public DbSet<ClassroomRegistrationTeacher> ClassroomRegistrationsTeacher { get; set; }
        //classroom tables
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Assessments> Assessments { get; set; }

    }
}
