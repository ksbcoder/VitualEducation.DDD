using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;
using VirtualEducation.DDD.Domain.Commons;

namespace VirtualEducation.DDD.Domain.Classroom.Events
{
    public class PreferencesAdded : DomainEvent
    {
        public Preferences Preferences { get; set; }

        public PreferencesAdded(Preferences preferences) : base("classroom.preferences.added")
        {
            Preferences = preferences;
        }
    }
}
