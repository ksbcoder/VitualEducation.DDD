using Newtonsoft.Json;
using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Student.Commands.Account;
using VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.Commands.Student;
using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.Entities.Rebuild;
using VirtualEducation.DDD.Domain.Student.Events;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;
using VirtualEducation.DDD.Domain.Student.ValueObjects.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;
using VirtualEducation.DDD.Domain.UseCases.Gateways;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;

namespace VirtualEducation.DDD.Domain.UseCases.UseCases
{
    public class StudentUseCase : IStudentUseCaseGateway
    {
        private readonly IStoredEventRepository<StoredEvent> _storedEventRepository;

        public StudentUseCase(IStoredEventRepository<StoredEvent> studentRepository)
        {
            _storedEventRepository = studentRepository;
        }

        #region Aggregate methods
        //for save aggregateid in events
        private string AggregateID;
        public async Task<Student.Entities.Student> CreateStudent(CreateStudentCommand createStudentCommand)
        {
            var student = new Student.Entities.Student(StudentID.Of(Guid.NewGuid()));
            AggregateID = student.StudentID.ID.ToString();

            var personalData = StudentPersonalData.Create(
                createStudentCommand.Name,
                createStudentCommand.LastName,
                createStudentCommand.Age,
                createStudentCommand.Gender
                );

            student.SetStudentID(student.StudentID);
            student.SetPersonalData(personalData);
            List<DomainEvent> domainEvents = student.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show the student on response
            var studentRebuild = new StudentRebuild();
            student = studentRebuild.CreateAggregate(domainEvents, student.StudentID);
            return student;
        }

        public async Task<Student.Entities.Student> AddAcountToStudent(StudentAddAccountCommand addAccountCommand)
        {
            var studentRebuild = new StudentRebuild();
            var listDomainEvents = await GetEventsByAggregateID(addAccountCommand.StudentId);
            var studentID = StudentID.Of(Guid.Parse(addAccountCommand.StudentId));
            var studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);
            AggregateID = studentID.ID.ToString();

            #region Account Creating
            var account = new AccountStudent(StudentAccountID.Of(Guid.NewGuid()));
            var accountDetail = StudentAccountDetail.Create(
                addAccountCommand.Username,
                addAccountCommand.CreatedAt
                );
            var email = StudentEmail.Create(
                addAccountCommand.PersonalMail,
                addAccountCommand.InstitutionalMail
                );
            var permissions = StudentPermissions.Create(
                addAccountCommand.Role
                );
            #endregion

            studentRebuilt.SetAccountToStudent(account);
            studentRebuilt.SetDetailsToAccount(accountDetail);
            studentRebuilt.SetEmailToAccount(email);
            studentRebuilt.SetPermissionsToAccount(permissions);
            List<DomainEvent> domainEvents = studentRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show student on response
            studentRebuild = new StudentRebuild();
            listDomainEvents = await GetEventsByAggregateID(addAccountCommand.StudentId);
            studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);
            return studentRebuilt;
        }

        public async Task<Student.Entities.Student> AddClassroomRegistrationToStudent(
            StudentAddClassroomRegistrationCommand addClassroomRegistrationCommand)
        {
            var studentRebuild = new StudentRebuild();
            var listDomainEvents = await GetEventsByAggregateID(addClassroomRegistrationCommand.StudentId);
            var studentID = StudentID.Of(Guid.Parse(addClassroomRegistrationCommand.StudentId));
            var studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);
            AggregateID = studentID.ID.ToString();

            var classroomRegistration = new ClassroomRegistrationStudent(StudentRegistrationID.Of(Guid.NewGuid()));
            var registrationDetail = StudentRegistrationDetail.Create(
                addClassroomRegistrationCommand.RegistratedAt
                );

            studentRebuilt.SetClassroomRegistration(classroomRegistration);
            studentRebuilt.SetDetailToClassroomRegistration(registrationDetail);
            List<DomainEvent> domainEvents = studentRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show student on response
            studentRebuild = new StudentRebuild();
            listDomainEvents = await GetEventsByAggregateID(addClassroomRegistrationCommand.StudentId);
            studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);
            return studentRebuilt;
        }

        public async Task<Student.Entities.Student> UpdateAccountDetail(
            StudentUpdateAccountDetailCommand updateAccountDetailCommand)
        {
            var studentRebuild = new StudentRebuild();
            var listDomainEvents = await GetEventsByAggregateID(updateAccountDetailCommand.StudentId);
            var studentID = StudentID.Of(Guid.Parse(updateAccountDetailCommand.StudentId));
            var studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);
            AggregateID = studentID.ID.ToString();

            var accountDetail = StudentAccountDetail.Create(
                updateAccountDetailCommand.Username,
                studentRebuilt.AccountStudent.AccountDetail.CreatedAt
                );

            studentRebuilt.SetAccountDetailUpdatedToAccount(accountDetail);
            List<DomainEvent> domainEvents = studentRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show student on response
            studentRebuild = new StudentRebuild();
            listDomainEvents = await GetEventsByAggregateID(updateAccountDetailCommand.StudentId);
            studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);
            return studentRebuilt;
        }

        public async Task<Student.Entities.Student> GetStudentById(string studentId)
        {
            var studentRebuild = new StudentRebuild();
            var listDomainEvents = await GetEventsByAggregateID(studentId);
            var studentID = StudentID.Of(Guid.Parse(studentId));
            var studentRebuilt = studentRebuild.CreateAggregate(listDomainEvents, studentID);

            return studentRebuilt;
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
                    //student
                    case StudentCreated studentCreated:
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
                    case AccountDetailUpdated accountDetailUpdated:
                        stored.EventBody = JsonConvert.SerializeObject(accountDetailUpdated);
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
                string nombre = $"VirtualEducation.DDD.Domain.Student.Events.{ev.StoredName}, VirtualEducation.DDD.Domain";
                Type tipo = Type.GetType(nombre);
                DomainEvent eventoParseado = (DomainEvent)JsonConvert.DeserializeObject(ev.EventBody, tipo);
                return eventoParseado;

            }).ToList();
        }
        #endregion
    }
}
