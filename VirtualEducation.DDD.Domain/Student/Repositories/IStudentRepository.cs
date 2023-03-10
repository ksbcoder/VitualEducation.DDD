namespace VirtualEducation.DDD.Domain.Student.Repositories
{
    public interface IStudentRepository
    {
        Task CreateStudent(Entities.Student student);
    }
}
