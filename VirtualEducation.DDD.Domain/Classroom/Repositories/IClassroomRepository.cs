namespace VirtualEducation.DDD.Domain.Classroom.Repositories
{
    public interface IClassroomRepository
    {
        Task CreateClassroom(Entities.Classroom classroom);
    }
}
