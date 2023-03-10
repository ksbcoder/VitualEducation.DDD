namespace VirtualEducation.DDD.Domain.Teacher.Repositories
{
    public interface ITeacherRepository
    {
        Task CreateTeacher(Entities.Teacher teacher);
    }
}
