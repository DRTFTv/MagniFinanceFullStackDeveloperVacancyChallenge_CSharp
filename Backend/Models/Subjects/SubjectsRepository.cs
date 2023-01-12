using Backend.Models.Courses;
using Backend.Models.Teachers;
using Backend.ModelView;

namespace Backend.Models.Subjects
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public SubjectsRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public bool Add(SubjectAddView Subject)
        {
            if (Subject == null)
                return false;

            CoursesModel courseModel = _universityDbContext.Courses.Where(s => s.Id == Subject.CourseId).FirstOrDefault();
            TeachersModel teacherModel = _universityDbContext.Teachers.Where(s => s.Id == Subject.TeacherId).FirstOrDefault();

            if (courseModel == null || teacherModel == null)
                return false;

            _universityDbContext.Subjects.Add(new SubjectsModel
            {
                Name = Subject.Name,
                CourseId = Subject.CourseId,
                TeacherId = Subject.TeacherId,
                CoursesNavigation = _universityDbContext.Courses.Where(s => s.Id == Subject.CourseId).FirstOrDefault(),
                TeachersNavigation = _universityDbContext.Teachers.Where(s => s.Id == Subject.TeacherId).FirstOrDefault(),
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<SubjectsModel> GetAll()
        {
            return _universityDbContext.Subjects;
        }

        public SubjectsModel GetById(int Id)
        {
            return _universityDbContext.Subjects.Where(s => s.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(SubjectUpdateByIdView Subject)
        {
            if (Subject == null)
                return false;

            SubjectsModel subjectModel = _universityDbContext.Subjects.Where(s => s.Id == Subject.Id).FirstOrDefault();

            if (subjectModel == null)
                return false;

            subjectModel.Name = !string.IsNullOrEmpty(Subject.Name) ? Subject.Name : subjectModel.Name;
            subjectModel.CourseId = Subject.CourseId ?? subjectModel.CourseId;
            subjectModel.TeacherId = Subject.TeacherId ?? subjectModel.TeacherId;
            subjectModel.CoursesNavigation = Subject.CourseId != null ? _universityDbContext.Courses.Where(s => s.Id == Subject.CourseId).FirstOrDefault() : subjectModel.CoursesNavigation;
            subjectModel.TeachersNavigation = Subject.TeacherId != null ? _universityDbContext.Teachers.Where(s => s.Id == Subject.TeacherId).FirstOrDefault()  : subjectModel.TeachersNavigation;

            _universityDbContext.Subjects.Update(subjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            SubjectsModel subjectModel = _universityDbContext.Subjects.Where(s => s.Id == Id).FirstOrDefault();

            if (subjectModel == null)
                return false;

            _universityDbContext.Attach(subjectModel);
            _universityDbContext.Remove(subjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
