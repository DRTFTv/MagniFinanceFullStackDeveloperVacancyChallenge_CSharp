using Backend.Models.Courses;
using Backend.Models.Grades;
using Backend.Models.Students;
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
                CoursesNavigation = courseModel,
                TeachersNavigation = teacherModel,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<SubjectGetAllView> GetAll()
        {
            List<SubjectGetAllView> subjects = new List<SubjectGetAllView>();

            _universityDbContext.Subjects.ToList().ForEach(s =>
            {
                subjects.Add(new SubjectGetAllView
                { 
                    Id = s.Id,
                    Name = s.Name,
                    CourseId = s.CourseId ?? 0, 
                    CourseName = _universityDbContext.Courses.Where(c => c.Id == s.CourseId).FirstOrDefault().Name, 
                    TeacherId = s.TeacherId ?? 0, 
                    TeacherName = _universityDbContext.Teachers.Where(t => t.Id == s.TeacherId).FirstOrDefault().Name, 
                });
            });

            return subjects;
        }

        public IEnumerable<SubjectHomeGetAllView> HomeGetAll()
        {
            List<SubjectHomeGetAllView> subjects = new List<SubjectHomeGetAllView>();

            _universityDbContext.Subjects.ToList().ForEach(s =>
            {
                List<StudentsModel> numberOfStudents = new List<StudentsModel>();
                List<GradesModel> grades = new List<GradesModel>();
                double dividend = 0;

                TeachersModel teacher = _universityDbContext.Teachers.Where(st => st.Id == s.TeacherId).FirstOrDefault();

                
                    _universityDbContext.Students_Subjects.Where(ss => ss.SubjectId == s.Id).ToList().ForEach(ss =>
                    {
                        if (numberOfStudents.Where(nos => nos.Id == ss.StudentId).FirstOrDefault() == null)
                            numberOfStudents.Add(_universityDbContext.Students.Where(s => s.Id == ss.StudentId).FirstOrDefault());
                        grades.Add(_universityDbContext.Grades.Where(g => g.Id == ss.GradeId).FirstOrDefault());
                    });
                


                grades.ForEach(g =>
                {
                    dividend += g.GradeOne + g.GradeTwo + g.GradeThree + g.GradeFour;
                });

                subjects.Add(new SubjectHomeGetAllView()
                {
                    Id = s.Id,
                    Name = s.Name,
                    TeacherName = teacher.Name,
                    TeacherBirthDate = teacher.BirthDate,
                    TeacherSalary = teacher.Salary,
                    NumberOfStudents = numberOfStudents.Count(),
                    GradeAvarege = grades.Count() != 0 ? dividend / grades.Count() : 0,
                });
            });

            return subjects;
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
            subjectModel.TeachersNavigation = Subject.TeacherId != null ? _universityDbContext.Teachers.Where(s => s.Id == Subject.TeacherId).FirstOrDefault() : subjectModel.TeachersNavigation;

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
