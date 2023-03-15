using Newtonsoft.Json;
using VirtualEducation.DDD.Domain.Classroom.Commands.Assessments;
using VirtualEducation.DDD.Domain.Classroom.Commands.Classroom;
using VirtualEducation.DDD.Domain.Classroom.Commands.Courses;
using VirtualEducation.DDD.Domain.Classroom.Commands.Student;
using VirtualEducation.DDD.Domain.Classroom.Commands.Teacher;
using VirtualEducation.DDD.Domain.Classroom.Entities;
using VirtualEducation.DDD.Domain.Classroom.Entities.Rebuild;
using VirtualEducation.DDD.Domain.Classroom.Events;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Assessment;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Classroom;
using VirtualEducation.DDD.Domain.Classroom.ValueObjects.Courses;
using VirtualEducation.DDD.Domain.Commons;
using VirtualEducation.DDD.Domain.Generics;
using VirtualEducation.DDD.Domain.Student.Entities.Rebuild;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Student;
using VirtualEducation.DDD.Domain.Teacher.Entities.Rebuild;
using VirtualEducation.DDD.Domain.Teacher.ValueObjects.Teacher;
using VirtualEducation.DDD.Domain.UseCases.Gateways;
using VirtualEducation.DDD.Domain.UseCases.Gateways.RepositoriesEvents;

namespace VirtualEducation.DDD.Domain.UseCases.UseCases
{
    public class ClassroomUseCase : IClassroomUseCaseGateway
    {
        private readonly IStoredEventRepository<StoredEvent> _storedEventRepository;

        public ClassroomUseCase(IStoredEventRepository<StoredEvent> classroomRepository)
        {
            _storedEventRepository = classroomRepository;
        }
        #region Aggregate methods
        private string AggregateID;
        public async Task<Classroom.Entities.Classroom> CreateClassroom(
            CreateClassroomCommand createClassroomCommand)
        {
            var classroom = new Classroom.Entities.Classroom(ClassroomID.Of(Guid.NewGuid()));
            AggregateID = classroom.ClassroomID.ID.ToString();

            var preferences = Preferences.Create(
                createClassroomCommand.Notifications
                );

            classroom.SetClassroomID(classroom.ClassroomID);
            classroom.SetPreferences(preferences);
            List<DomainEvent> domainEvents = classroom.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show the classroom on response
            var classroomRebuild = new ClassroomRebuild();
            classroom = classroomRebuild.CreateAggregate(domainEvents, classroom.ClassroomID);
            return classroom;
        }
        public async Task<Classroom.Entities.Classroom> AddCoursesToClassroom(
            AddCoursesCommand addCoursesCommand)
        {
            var classroomRebuild = new ClassroomRebuild();
            var listDomainEvents = await GetEventsClassroomByAggregateID(addCoursesCommand.ClassroomId);
            var classroomID = ClassroomID.Of(Guid.Parse(addCoursesCommand.ClassroomId));
            var classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            AggregateID = classroomID.ID.ToString();

            #region creating course
            var courseToAdd = new Course(CourseID.Of(Guid.NewGuid()));
            var courseDetail = CourseDetail.Create(
                addCoursesCommand.CourseName,
                addCoursesCommand.CourseDescription,
                addCoursesCommand.DateStart,
                addCoursesCommand.DateEnd,
                addCoursesCommand.Duration
                );
            #endregion

            classroomRebuilt.SetCourseToClassroom(courseToAdd);
            classroomRebuilt.SetDetailToCourse(courseDetail);

            List<DomainEvent> domainEvents = classroomRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            classroomRebuild = new ClassroomRebuild();
            listDomainEvents = await GetEventsClassroomByAggregateID(addCoursesCommand.ClassroomId);
            classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            return classroomRebuilt;
        }
        public async Task<Classroom.Entities.Classroom> AddAssessmentsToClassroom(
            AddAssessmentsCommand addAssessmentsCommand)
        {
            var classroomRebuild = new ClassroomRebuild();
            var listDomainEvents = await GetEventsClassroomByAggregateID(addAssessmentsCommand.ClassroomId);
            var classroomID = ClassroomID.Of(Guid.Parse(addAssessmentsCommand.ClassroomId));
            var classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            AggregateID = classroomID.ID.ToString();

            #region creating assessment
            var assessmentToAdd = new Assessment(AssessmentID.Of(Guid.NewGuid()));
            var qualification = Qualification.Create(
                addAssessmentsCommand.Rating,
                addAssessmentsCommand.Feedback
                );
            #endregion

            classroomRebuilt.SetAssessmentToClassroom(assessmentToAdd);
            classroomRebuilt.SetQualificationToAssessment(qualification);

            List<DomainEvent> domainEvents = classroomRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            classroomRebuild = new ClassroomRebuild();
            listDomainEvents = await GetEventsClassroomByAggregateID(addAssessmentsCommand.ClassroomId);
            classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            return classroomRebuilt;
        }
        public async Task<Classroom.Entities.Classroom> UpdateAssessment(
            UpdateAssessmentCommand updateAssessmentCommand)
        {
            var classroomRebuild = new ClassroomRebuild();
            var listDomainEvents = await GetEventsClassroomByAggregateID(updateAssessmentCommand.ClassroomId);
            var classroomID = ClassroomID.Of(Guid.Parse(updateAssessmentCommand.ClassroomId));
            var classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            AggregateID = classroomID.ID.ToString();

            #region updating assessment
            var qualification = Qualification.Create(
                    updateAssessmentCommand.Rating,
                    updateAssessmentCommand.Feedback
                    );
            bool found = false;
            foreach (var ass in classroomRebuilt.Assessments)
            {
                if (ass.AssessmentID.ToString().Equals(updateAssessmentCommand.AssessmentId))
                {
                    classroomRebuilt.SetQualificationUpdatedToAssessment(
                        qualification,
                        updateAssessmentCommand.AssessmentId
                        );
                    found = true;
                }
            }
            if (!found)
            {
                throw new Exception($"There isn't an assessment with this ID: {updateAssessmentCommand.AssessmentId}.");
            }
            #endregion

            List<DomainEvent> domainEvents = classroomRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            //show the classroom on response
            classroomRebuild = new ClassroomRebuild();
            listDomainEvents = await GetEventsClassroomByAggregateID(updateAssessmentCommand.ClassroomId);
            classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            return classroomRebuilt;

        }
        public async Task<Classroom.Entities.Classroom> GetClassroomById(string classroomId)
        {
            var classroomRebuild = new ClassroomRebuild();
            var listDomainEvents = await GetEventsClassroomByAggregateID(classroomId);
            var classroomID = ClassroomID.Of(Guid.Parse(classroomId));
            var classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEvents, classroomID);
            return classroomRebuilt;
        }

        public async Task<Classroom.Entities.Classroom> AddStudentToClassroom(ClassroomAddStudentCommand classroomAddStudentCommand)
        {
            var classroomRebuild = new ClassroomRebuild();
            var listDomainEventsClassroom = await GetEventsClassroomByAggregateID(classroomAddStudentCommand.ClassroomId);
            var classroomID = ClassroomID.Of(Guid.Parse(classroomAddStudentCommand.ClassroomId));
            var classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEventsClassroom, classroomID);
            AggregateID = classroomID.ID.ToString();

            var studentRebuild = new StudentRebuild();
            var listDomainEventsStudent = await GetEventsByStudentAggregateID(classroomAddStudentCommand.StudentId);
            var studentID = StudentID.Of(Guid.Parse(classroomAddStudentCommand.StudentId));
            var studentRebuilt = studentRebuild.CreateAggregate(listDomainEventsStudent, studentID);

            classroomRebuilt.SetStudent(studentRebuilt.StudentID);

            List<DomainEvent> domainEvents = classroomRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            classroomRebuild = new ClassroomRebuild();
            listDomainEventsClassroom = await GetEventsClassroomByAggregateID(classroomAddStudentCommand.ClassroomId);
            classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEventsClassroom, classroomID);
            return classroomRebuilt;
        }

        public async Task<Classroom.Entities.Classroom> AddTeacherToClassroom(ClassroomAddTeacherCommand classroomAddTeacherCommand)
        {
            var classroomRebuild = new ClassroomRebuild();
            var listDomainEventsClassroom = await GetEventsClassroomByAggregateID(classroomAddTeacherCommand.ClassroomId);
            var classroomID = ClassroomID.Of(Guid.Parse(classroomAddTeacherCommand.ClassroomId));
            var classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEventsClassroom, classroomID);
            AggregateID = classroomID.ID.ToString();

            var teacherRebuild = new TeacherRebuild();
            var listDomainEventsTeacher = await GetEventsByTeacherAggregateID(classroomAddTeacherCommand.TeacherId);
            var teacherID = TeacherID.Of(Guid.Parse(classroomAddTeacherCommand.TeacherId));
            var teacherRebuilt = teacherRebuild.CreateAggregate(listDomainEventsTeacher, teacherID);

            classroomRebuilt.SetTeacher(teacherRebuilt.TeacherID);

            List<DomainEvent> domainEvents = classroomRebuilt.GetUncommittedChanges();
            await SaveEvents(domainEvents);

            classroomRebuild = new ClassroomRebuild();
            listDomainEventsClassroom = await GetEventsClassroomByAggregateID(classroomAddTeacherCommand.ClassroomId);
            classroomRebuilt = classroomRebuild.CreateAggregate(listDomainEventsClassroom, classroomID);
            return classroomRebuilt;
        }
        #endregion

        #region Domain events
        public async Task SaveEvents(List<DomainEvent> list)
        {
            var array = list.ToArray();
            for (var index = 0; index < array.Length; index++)
            {
                //set the aggregate id to events
                array[index].SetAggregateId(AggregateID);
                var stored = new StoredEvent();
                stored.AggregateId = array[index].GetAggregateId();
                stored.StoredName = array[index].GetAggregate();
                switch (array[index])
                {
                    //classroom
                    case ClassroomCreated classroomCreated:
                        stored.EventBody = JsonConvert.SerializeObject(classroomCreated);
                        break;
                    case PreferencesAdded preferencesAdded:
                        stored.EventBody = JsonConvert.SerializeObject(preferencesAdded);
                        break;
                    //courses
                    case CourseAdded courseAdded:
                        stored.EventBody = JsonConvert.SerializeObject(courseAdded);
                        break;
                    case CourseDetailAdded courseDetail:
                        stored.EventBody = JsonConvert.SerializeObject(courseDetail);
                        break;
                    //assessments
                    case AssessmentAdded assessmentsAdded:
                        stored.EventBody = JsonConvert.SerializeObject(assessmentsAdded);
                        break;
                    case AssessmentQualificationAdded assessmentQualificationAdded:
                        stored.EventBody = JsonConvert.SerializeObject(assessmentQualificationAdded);
                        break;
                    case QualificationUpdated assessmentUpdated:
                        stored.EventBody = JsonConvert.SerializeObject(assessmentUpdated);
                        break;
                    //student
                    case StudentAdded studentAdded:
                        stored.EventBody = JsonConvert.SerializeObject(studentAdded);
                        break;
                    //teacher
                    case TeacherAdded teacherAdded:
                        stored.EventBody = JsonConvert.SerializeObject(teacherAdded);
                        break;
                }
                await _storedEventRepository.AddAsync(stored);
            }
            await _storedEventRepository.SaveChangesAsync();
        }
        public async Task<List<DomainEvent>> GetEventsClassroomByAggregateID(string aggregateId)
        {
            var listadoStoredEvents = await _storedEventRepository.GetEventsByAggregateId(aggregateId);

            if (listadoStoredEvents == null)
                throw new ArgumentException("There isn't an aggregate with this id");

            return listadoStoredEvents.Select(ev =>
            {
                string nombre = $"VirtualEducation.DDD.Domain.Classroom.Events.{ev.StoredName}, VirtualEducation.DDD.Domain";
                Type tipo = Type.GetType(nombre);
                DomainEvent eventoParseado = (DomainEvent)JsonConvert.DeserializeObject(ev.EventBody, tipo);
                return eventoParseado;

            }).ToList();
        }

        public async Task<List<DomainEvent>> GetEventsByStudentAggregateID(string aggregateId)
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

        public async Task<List<DomainEvent>> GetEventsByTeacherAggregateID(string aggregateId)
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
