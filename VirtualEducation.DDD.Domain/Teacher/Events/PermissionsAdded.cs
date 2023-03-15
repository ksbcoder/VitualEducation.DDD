using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Teacher.Events
{
    public class PermissionsAdded : DomainEvent
    {
        public TeacherPermissions Permissions { get; set; }

        public PermissionsAdded(TeacherPermissions permissions) : base("teacher.account.permissions.added")
        {
            Permissions = permissions;
        }
    }
}
