using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Events
{
    public class PermissionsAdded : DomainEvent
    {
        public Permissions Permissions { get; set; }

        public PermissionsAdded(Permissions permissions) : base("student.account.permissions.added")
        {
            Permissions = permissions;
        }
    }
}
