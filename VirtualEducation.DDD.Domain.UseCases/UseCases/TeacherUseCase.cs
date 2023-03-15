using Newtonsoft.Json;
using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Teacher.Commands.Account;
using VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.Commands.Teacher;
using VirtualEducation.DDD.Domain.Teacher.Entities;
using VirtualEducation.DDD.Domain.Teacher.Entities.Rebuild;
using VirtualEducation.DDD.Domain.Teacher.Events;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;
using VirtualEducation.DDD.Domain.UseCases.Gateways;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;

namespace VirtualEducation.DDD.Domain.UseCases.UseCases
{
    public class TeacherUseCase : ITeacherUseCaseGateway
    {
        private readonly IStoredEventRepository<StoredEvent> _storedEventRepository;

        public TeacherUseCase(IStoredEventRepository<StoredEvent> teacherRepository)
        {
            _storedEventRepository = teacherRepository;
        }

        #region Aggregate methods
        private string AggregateID;
        public async Task<Teacher.Entities.Teacher> CreateTeacher(CreateTeacherCommand createTeacherCommand)
        {
            var teacher = new Teacher.Entities.Teacher(TeacherID.Of(Guid.NewGuid()));
            AggregateID = teacher.TeacherID.ID.ToString();

            var personalData = TeacherPersonalData.Create(
                createTeacherCommand.Name,
                createTeacherCommand.LastName,
                createTeacherCommand.Age,
                createTeacherCommand.Gender
                );

            teacher.SetTeacherID(teacher.TeacherID);
            teacher.SetPersonalData(personalData);
            List<DomainEvent> domainEvents = teacher.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show the teacher on response
            var teacherRebuild = new TeacherRebuild();
            teacher = teacherRebuild.CreateAggregate(domainEvents, teacher.TeacherID);
            return teacher;
        }

        public async Task<Teacher.Entities.Teacher> AddAcountToTeacher(TeacherAddAccountCommand addAccountCommand)
        {
            var teacherRebuild = new TeacherRebuild();
            var listDomainEvents = await GetEventsByAggregateID(addAccountCommand.TeacherId);
            var teacherID = TeacherID.Of(Guid.Parse(addAccountCommand.TeacherId));
            var teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);
            AggregateID = teacherID.ID.ToString();

            #region account creating
            var account = new AccountTeacher(TeacherAccountID.Of(Guid.NewGuid()));
            var accountDetail = TeacherAccountDetail.Create(
                addAccountCommand.Username,
                addAccountCommand.CreatedAt
                );
            var email = TeacherEmail.Create(
                addAccountCommand.PersonalMail,
                addAccountCommand.InstitutionalMail
                );
            var permissions = TeacherPermissions.Create(
                addAccountCommand.Role
                );
            #endregion

            #region set events
            teacherRebuilt.SetAccountToTeacher(account);
            teacherRebuilt.SetDetailsToAccount(accountDetail);
            teacherRebuilt.SetEmailToAccount(email);
            teacherRebuilt.SetPermissionsToAccount(permissions);
            List<DomainEvent> domainEvents = teacherRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);
            #endregion

            //show the teacher on response
            teacherRebuild = new TeacherRebuild();
            listDomainEvents = await GetEventsByAggregateID(addAccountCommand.TeacherId);
            teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);
            return teacherRebuilt;
        }

        public async Task<Teacher.Entities.Teacher> AddClassroomRegistrationToTeacher(
                       TeacherAddClassroomRegistrationCommand addClassroomRegistrationCommand)
        {
            var teacherRebuild = new TeacherRebuild();
            var listDomainEvents = await GetEventsByAggregateID(addClassroomRegistrationCommand.TeacherId);
            var teacherID = TeacherID.Of(Guid.Parse(addClassroomRegistrationCommand.TeacherId));
            var teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);
            AggregateID = teacherID.ID.ToString();

            #region classroom registration creating
            var classroomRegistration = new ClassroomRegistrationTeacher(TeacherRegistrationID.Of(Guid.NewGuid()));
            var registrationDetail = TeacherRegistrationDetail.Create(
                addClassroomRegistrationCommand.RegistratedAt
                );
            #endregion

            teacherRebuilt.SetClassroomRegistration(classroomRegistration);
            teacherRebuilt.SetDetailToClassroomRegistration(registrationDetail);
            List<DomainEvent> domainEvents = teacherRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show the teacher on response
            teacherRebuild = new TeacherRebuild();
            listDomainEvents = await GetEventsByAggregateID(addClassroomRegistrationCommand.TeacherId);
            teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);
            return teacherRebuilt;
        }

        public async Task<Teacher.Entities.Teacher> UpdateEmail(TeacherUpdateEmailCommand updateEmailCommand)
        {
            var teacherRebuild = new TeacherRebuild();
            var listDomainEvents = await GetEventsByAggregateID(updateEmailCommand.TeacherId);
            var teacherID = TeacherID.Of(Guid.Parse(updateEmailCommand.TeacherId));
            var teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);
            AggregateID = teacherID.ID.ToString();

            var email = TeacherEmail.Create(
                updateEmailCommand.PersonalMail,
                teacherRebuilt.AccountTeacher.Email.InstitutionalMail
                );

            teacherRebuilt.SetEmailUpdatedToAccount(email);
            List<DomainEvent> domainEvents = teacherRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show the teacher on response
            teacherRebuild = new TeacherRebuild();
            listDomainEvents = await GetEventsByAggregateID(updateEmailCommand.TeacherId);
            teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);
            return teacherRebuilt;
        }

        public async Task<Teacher.Entities.Teacher> GetTeacherById(string teacherId)
        {
            var teacherRebuild = new TeacherRebuild();
            var listDomainEvents = await GetEventsByAggregateID(teacherId);
            var teacherID = TeacherID.Of(Guid.Parse(teacherId));
            var teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEvents, teacherID);

            return teacherRebuilt;
        }
        #endregion

        #region Domain events
        private async Task SaveEvents(List<DomainEvent> list)
        {
            var array = list.ToArray();
            for (var index = 0; index < array.Length; index++)
            {
                //set aggregate id to events
                array[index].SetAggregateId(AggregateID);
                var stored = new StoredEvent();
                stored.AggregateId = array[index].GetAggregateId();
                stored.StoredName = array[index].GetAggregate();
                switch (array[index])
                {
                    //teacher
                    case TeacherCreated studentCreated:
                        stored.EventBody = JsonConvert.SerializeObject(studentCreated);
                        break;
                    case PersonalDataAdded personalDataAdded:
                        stored.EventBody = JsonConvert.SerializeObject(personalDataAdded);
                        break;
                    //account
                    case AccountAdded accountAdded:
                        stored.EventBody = JsonConvert.SerializeObject(accountAdded);
                        break;
                    case AccountDetailAdded accountDetailAdded:
                        stored.EventBody = JsonConvert.SerializeObject(accountDetailAdded);
                        break;
                    case EmailAdded emailAdded:
                        stored.EventBody = JsonConvert.SerializeObject(emailAdded);
                        break;
                    case PermissionsAdded permissionsAdded:
                        stored.EventBody = JsonConvert.SerializeObject(permissionsAdded);
                        break;
                    case EmailUpdated emailUpdated:
                        stored.EventBody = JsonConvert.SerializeObject(emailUpdated);
                        break;
                    //classroom
                    case ClassroomRegistrationAdded classroomRegistrationAdded:
                        stored.EventBody = JsonConvert.SerializeObject(classroomRegistrationAdded);
                        break;
                    case ClassroomRegistrationDetailAdded classroomRegistrationDetailAdded:
                        stored.EventBody = JsonConvert.SerializeObject(classroomRegistrationDetailAdded);
                        break;
                }
                await _storedEventRepository.AddAsync(stored);
            }
            await _storedEventRepository.SaveChangesAsync();
        }

        public async Task<List<DomainEvent>> GetEventsByAggregateID(string aggregateId)
        {
            var listadoStoredEvents = await _storedEventRepository.GetEventsByAggregateId(aggregateId);

            if (listadoStoredEvents == null)
                throw new ArgumentException("There isn't an aggregate with this id");

            return listadoStoredEvents.Select(ev =>
            {
                string nombre = $"VirtualEducation.DDD.Domain.Teacher.Events.{ev.StoredName}, VirtualEducation.DDD.Domain";
                Type tipo = Type.GetType(nombre);
                DomainEvent eventoParseado = (DomainEvent)JsonConvert.DeserializeObject(ev.EventBody, tipo);
                return eventoParseado;

            }).ToList();
        }
        #endregion
    }
}
