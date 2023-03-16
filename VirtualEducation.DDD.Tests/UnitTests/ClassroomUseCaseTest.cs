using Moq;
using VirtualEducation.DDD.Domain.Classroom.Commands.Assessments;
using VirtualEducation.DDD.Domain.Classroom.Commands.Classroom;
using VirtualEducation.DDD.Domain.Classroom.Commands.Courses;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;
using VirtualEducation.DDD.Domain.UseCases.UseCases;
using VirtualEducation.DDD.Tests.Builders;
using VirtualEducation.DDD.Tests.Builders.Classroom;

namespace VirtualEducation.DDD.Tests.UnitTests
{
    public class ClassroomUseCaseTest
    {
        private readonly Mock<IStoredEventRepository<StoredEvent>> _mockRepository;

        //before each
        public ClassroomUseCaseTest()
        {
            _mockRepository = new();
        }

        #region tests
        [Fact]
        public async Task Create_Classroom()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());
            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<int>(200));
            //Act
            var useCase = new ClassroomUseCase(_mockRepository.Object);
            await useCase.CreateClassroom(GetClassroomCommand());
            //Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Add_Course_To_Classroom()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .ReturnsAsync(GetListStoredEvent());

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new ClassroomUseCase(_mockRepository.Object);
            await useCase.AddCoursesToClassroom(GetCoursesCommand());

            //Assert
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));

            _mockRepository.Verify(x => x.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Add_Assessment_To_Classroom()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .ReturnsAsync(GetListStoredEvent());

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEvent());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new ClassroomUseCase(_mockRepository.Object);
            await useCase.AddAssessmentsToClassroom(GetAssessmentsCommand());

            //Assert
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
            _mockRepository.Verify(x => x.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));
            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Update_Assessment()
        {
            //Arrange
            _mockRepository.Setup(repo => repo.GetEventsByAggregateId(It.IsAny<string>()))
                .Returns(Task.FromResult(GetListStoredEvent()));

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetStoredEventForUpdate());

            _mockRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //Act
            var useCase = new ClassroomUseCase(_mockRepository.Object);
            await useCase.UpdateAssessment(GetUpdateAssessmentCommand());

            //Assert
            _mockRepository.Verify(r => r.GetEventsByAggregateId(It.IsAny<string>()), Times.Exactly(2));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<StoredEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(1));

            _mockRepository.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }
        #endregion


        #region private builders methods
        private CreateClassroomCommand GetClassroomCommand()
        {
            return new CreateClassroomCommandBuilder()
                    .WithNotifications(true)
                    .Build();
        }

        private AddCoursesCommand GetCoursesCommand()
        {
            return new AddCourseCommandBuilder()
                        .WithClassroomId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                        .WithCourseName("DDD")
                        .WithCourseDescription("Learning pattern")
                        .WithDateStart(DateTime.Now)
                        .WithDateEnd(DateTime.Now)
                        .WithDuration(40)
                        .Build();
        }

        private AddAssessmentsCommand GetAssessmentsCommand() =>
            new AddAssessmentCommandBuilder()
                .WithClassroomId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                .WithRating(100)
                .WithFeedback("Buen trabajo!")
                .Build();

        private UpdateAssessmentCommand GetUpdateAssessmentCommand() =>
            new UpdateAssessmentCommandBuilder()
                .WithClassroomId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                .WithAssessmentId("d1ee6ce8-09eb-4e3d-ba3f-cbb8e62a3613")
                .WithRating(100)
                .WithFeedback("Mejoraste!")
                .Build();

        //events
        private StoredEvent GetStoredEvent()
        {
            return new StoredEventBuilder()
                    .WithStoredId(1)
                    .WithStoredName("ClassroomCreated")
                    .WithAggregateId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                    .WithEventBody("{\"Type\":\"classroom.created\",\"ClassroomID\":\"VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom.ClassroomID\"}")
                    .Build();
        }

        private List<StoredEvent> GetListStoredEvent() =>
            new()
            {
                new StoredEventBuilder()
                    .WithStoredId(1)
                    .WithStoredName("ClassroomCreated")
                    .WithAggregateId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                    .WithEventBody("{\"Type\":\"classroom.created\",\"ClassroomID\":\"VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom.ClassroomID\"}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(2)
                    .WithStoredName("PreferencesAdded")
                    .WithAggregateId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                    .WithEventBody("{\"Type\":\"classroom.preferences.added\",\"Preferences\":{\"Notifications\":true}}")
                    .Build(),

                new StoredEventBuilder()
                    .WithStoredId(3)
                    .WithStoredName("AssessmentAdded")
                    .WithAggregateId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                    .WithEventBody("{\"Type\":\"classroom.assessment.added\",\"Assessment\":{\"" +
                    "AssessmentID\":\"d1ee6ce8-09eb-4e3d-ba3f-cbb8e62a3613\",\"Qualification\":null}}")
                    .Build(),
            };

        private StoredEvent GetStoredEventForUpdate() =>
            new StoredEventBuilder()
                    .WithStoredId(4)
                    .WithStoredName("QualificationUpdated")
                    .WithAggregateId("56b877ea-469a-4b0d-8393-decdedf7f0a4")
                    .WithEventBody("{\"Type\":\"classroom.assessment.qualification.updated\",\"" +
                "AssessmentId\":\"d1ee6ce8-09eb-4e3d-ba3f-cbb8e62a3613\",\"Qualification\":{\"Rating\":100,\"Feedback\":\"Mejoraste!\"}}")
                    .Build();
        #endregion
    }
}
