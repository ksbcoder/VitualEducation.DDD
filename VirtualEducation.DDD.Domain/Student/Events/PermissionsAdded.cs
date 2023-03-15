using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class PermissionsAdded : DomainEvent
    {
        public StudentPermissions Permissions { get; set; }

        public PermissionsAdded(StudentPermissions permissions) : base("student.account.permissions.added")
        {
            Permissions = permissions;
        }
    }
}
