using Moq;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Teacher.Commands.Account;
using VirtualEducation.DDD.Domain.Teacher.Commands.ClassroomRegistration;
using VirtualEducation.DDD.Domain.Teacher.Commands.Teacher;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;
using VirtualEducation.DDD.Domain.UseCases.UseCases;
using VirtualEducation.DDD.Tests.Builders;
using VirtualEducation.DDD.Tests.Builders.Teacher;

namespace VirtualEducation.DDD.Tests.UnitTests
{
    public class TeacherUseCaseTest
    {
        private readonly Mock<IStoredEventRepository<StoredEvent>> _mockRepository;

        //before each
        public TeacherUseCaseTest()
        {
            _mockRepository = new();
        }

        #region tests
        [Fact]
        public async Task Create_Teacher()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<int>(200));

            //Act
            var useCase = new TeacherUseCase(_mockRepository.Object);
            await useCase.CreateTeacher(GetTeacherCommand());

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
            var useCase = new TeacherUseCase(_mockRepository.Object);
            await useCase.AddAcountToTeacher(GetAddAccountCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(4));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Add_ClassroomRegitration_To_Teacher()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new TeacherUseCase(_mockRepository.Object);
            await useCase.AddClassroomRegistrationToTeacher(GetAddClassroomRegistrationCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Update_Email()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEventForUpdate());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new TeacherUseCase(_mockRepository.Object);
            await useCase.UpdateEmail(GetUpdateAccountDetailCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }
        #endregion


        #region private builders methods
        private CreateTeacherCommand GetTeacherCommand()
        {
            return new CreateTeacherCommandBuilder()
                    .WithName("Kevin")
                    .WithLastName("Baquero")
                    .WithAge(22)
                    .WithGender("Male")
                    .Build();
        }

        private TeacherAddAccountCommand GetAddAccountCommand()
        {
            return new TeacherAddAccountCommandBuilder()
                    .WithTeacherId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithUserName("johndoe")
                    .WithPersonalMail("johndoe@gmail.com")
                    .WithInstitutionalMail("johndoe@university.edu")
                    .WithRole("Student")
                    .Build();
        }

        private TeacherAddClassroomRegistrationCommand GetAddClassroomRegistrationCommand() =>
            new TeacherAddClassroomRegistrationCommandBuilder()
                    .WithTeacherId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithCreatedAt(DateTime.Now)
                    .Build();

        private TeacherUpdateEmailCommand GetUpdateAccountDetailCommand() =>
            new TeacherUpdateEmailCommandBuilder()
                    .WithTeacherId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithPersonalEmail("test@test.com")
                    .Build();

        //events
        private StoredEvent GetStoredEvent()
        {
            return new StoredEventBuilder()
                    .WithStoredId(1)
                    .WithStoredName("TeacherCreated")
                    .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithEventBody("{\"Type\":\"teacher.created\",\"TeacherID\":\"VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher.TeacherID\"}")
                    .Build();
        }

        private List<StoredEvent> GetListStoredEvent() =>
            new()
            {
                new StoredEventBuilder()
                    .WithStoredId(1)
                    .WithStoredName("TeacherCreated")
                    .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithEventBody("{\"Type\":\"teacher.created\",\"TeacherID\":\"VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher.TeacherID\"}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(2)
                    .WithStoredName("PersonalDataAdded")
                    .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithEventBody("{\"Type\":\"teacher.personaldata.added\",\"PersonalData\":{\"Name\":\"Adryan\",\"LastName\":\"Ynfante\",\"Age\":23,\"Gender\":\"Male\"}}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(3)
                    .WithStoredName("AccountAdded")
                    .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithEventBody("{\"Type\":\"teacher.account.added\",\"AccountTeacher\":{\"" +
                        "AccountID\":{\"ID\":\"979da584-599d-4746-b9c8-e9459bd07a47\"},\"AccountDetail\":null,\"Email\":null,\"Permissions\":null}}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(4)
                    .WithStoredName("EmailAdded")
                    .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                    .WithEventBody("{\"Type\":\"teacher.account.email.added\",\"Email\":{\"" +
                        "PersonalMail\":\"adryan@hotmail.com\",\"InstitutionalMail\":\"adryan.ynfante@sofka.com.co\"}}")
                    .Build()
            };

        private StoredEvent GetStoredEventForUpdate() =>
            new StoredEventBuilder()
                .WithStoredId(5)
                .WithStoredName("EmailUpdated")
                .WithAggregateId("8defaac4-6606-43f2-9491-6773b93f534c")
                .WithEventBody("{\"Type\":\"teacher.account.email.added\",\"Email\":{\"" +
                "PersonalMail\":\"test@test.com\",\"InstitutionalMail\":\"adryan.ynfante@sofka.com.co\"}}")
                .Build();
        #endregion
    }
}
