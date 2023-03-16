using Moq;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Student.Commands.Account;
using VirtualEducation.DDD.Domain.Student.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Student.Commands.Student;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;
using VirtualEducation.DDD.Domain.UseCases.UseCases;
using VirtualEducation.DDD.Tests.Builders;
using VirtualEducation.DDD.Tests.Builders.Student;

namespace VirtualEducation.DDD.Tests.UnitTests
{
    public class StudentUseCaseTest
    {
        private readonly Mock<IStoredEventRepository<StoredEvent>> _mockRepository;

        //before each
        public StudentUseCaseTest()
        {
            _mockRepository = new();
        }

        #region tests
        [Fact]
        public async Task Create_Student()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<int>(200));

            //Act
            var useCase = new StudentUseCase(_mockRepository.Object);
            await useCase.CreateStudent(GetStudentCommand());

            //Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Add_Account_To_Student()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new StudentUseCase(_mockRepository.Object);
            await useCase.AddAcountToStudent(GetAddAccountCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(4));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Add_ClassroomRegistration_To_Student()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new StudentUseCase(_mockRepository.Object);
            await useCase.AddClassroomRegistrationToStudent(GetAddClassroomRegistrationCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));

        }

        [Fact]
        public async Task Update_AccountDetail()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEventForUpdate());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new StudentUseCase(_mockRepository.Object);
            await useCase.UpdateAccountDetail(GetUpdateAccountDetailCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }
        #endregion


        #region private builders methods
        private CreateStudentCommand GetStudentCommand() =>
            new CreateStudentCommandBuilder()
                .WithName("John")
                .WithLastName("Doe")
                .WithAge(25)
                .WithGender("Male")
                .Build();

        private StudentAddAccountCommand GetAddAccountCommand() =>
        new StudentAddAccountCommandBuilder()
                .WithStudentId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                .WithUserName("johndoe")
                .WithCreatedAt(DateTime.Now)
                .WithPersonalMail("johndoe@gmail.com")
                .WithInstitutionalMail("johndoe@university.edu")
                .WithRole("Student")
                .Build();

        private StudentAddClassroomRegistrationCommand GetAddClassroomRegistrationCommand() =>
            new StudentAddClassroomRegistrationCommandBuilder()
                .WithStudentId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                .WithCreatedAt(DateTime.Now)
                .Build();

        private StudentUpdateAccountDetailCommand GetUpdateAccountDetailCommand() =>
            new StudentUpdateAccountDetailCommandBuilder()
                    .WithStudentId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                    .WithUsername("SantiB")
                    .Build();

        //events
        private StoredEvent GetStoredEvent() =>
            new StoredEventBuilder()
                .WithStoredId(1)
                .WithStoredName("StudentCreated")
                .WithAggregateId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                .WithEventBody("{\"Type\":\"student.created\",\"StudentID\":\"5387a47d-98ea-40cd-8c65-8dd93e98a4b3\"}")
                .Build();

        private List<StoredEvent> GetListStoredEvent() =>
            new()
            {
                new StoredEventBuilder()
                    .WithStoredId(1)
                    .WithStoredName("StudentCreated")
                    .WithAggregateId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                    .WithEventBody("{\"Type\":\"student.created\",\"StudentID\":\"5387a47d-98ea-40cd-8c65-8dd93e98a4b3\"}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(2)
                    .WithStoredName("PersonalDataAdded")
                    .WithAggregateId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                    .WithEventBody("{\"Type\":\"student.personaldata.added\",\"PersonalData\":{\"Name\":\"Kevin\",\"LastName\":\"Baquero\",\"Age\":22,\"Gender\":\"Male\"}}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(3)
                    .WithStoredName("AccountAdded")
                    .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithEventBody("{\"Type\":\"student.account.added\",\"AccountStudent\":{\"" +
                        "AccountID\":{\"ID\":\"9199e1bb-5303-4b75-8f30-6400259c87b2\"},\"AccountDetail\":null,\"Email\":null,\"Permissions\":null}}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(4)
                    .WithStoredName("AccountDetailAdded")
                    .WithAggregateId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                    .WithEventBody("{\"Type\":\"student.account.detail.added\",\"AccountDetail\":{\"Username\":\"Santi\",\"CreatedAt\":\"2023-03-15T03:23:41.168Z\"}}")
                    .Build()
            };

        private StoredEvent GetStoredEventForUpdate() =>
                new StoredEventBuilder()
                    .WithStoredId(4)
                    .WithStoredName("AccountDetailUpdated")
                    .WithAggregateId("5387a47d-98ea-40cd-8c65-8dd93e98a4b3")
                    .WithEventBody("{\"Type\":\"student.account.detail.updated\",\"AccountDetail\":{\"Username\":\"SantiB\",\"CreatedAt\":\"2023-03-15T03:23:41.168Z\"}}")
                    .Build();
        #endregion
    }
}
