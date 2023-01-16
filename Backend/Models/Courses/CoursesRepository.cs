using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Teachers;
using Backend.ModelView;
using Newtonsoft.Json.Linq;

namespace Backend.Models.Courses
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public CoursesRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public bool Add(CourseAddView Course)
        {
            if (Course == null)
                return false;


            _universityDbContext.Courses.Add(new CoursesModel
            {
                Name = Course.Name,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<CoursesModel> GetAll()
        {
            return _universityDbContext.Courses;
        }

        public IEnumerable<CourseHomeGetAllView> HomeGetAll()
        {
            List<CourseHomeGetAllView> courses = new List<CourseHomeGetAllView>();

            _universityDbContext.Courses.ToList().ForEach(c =>
            {
                List<StudentsModel> numberOfStudents = new List<StudentsModel>();
                List<TeachersModel> numberOfTeachers = new List<TeachersModel>();
                List<GradesModel> grades = new List<GradesModel>();
                double dividend = 0;

                _universityDbContext.Subjects.ToList().ForEach(s =>
                {
                    if (numberOfTeachers.Where(not => not.Id == s.TeacherId).FirstOrDefault() == null)
                        numberOfTeachers.Add(_universityDbContext.Teachers.Where(t => t.Id == s.TeacherId).FirstOrDefault());
                });

                _universityDbContext.Subjects.Where(s => s.CourseId == c.Id).ToList().ForEach(s =>
                {
                    _universityDbContext.Students_Subjects.Where(ss => ss.SubjectId == s.Id).ToList().ForEach(ss =>
                    {
                        if (numberOfStudents.Where(nos => nos.Id == ss.StudentId).FirstOrDefault() == null)
                            numberOfStudents.Add(_universityDbContext.Students.Where(s => s.Id == ss.StudentId).FirstOrDefault());
                        grades.Add(_universityDbContext.Grades.Where(g => g.Id == ss.GradeId).FirstOrDefault());
                        
                    });
                });


                grades.ForEach(g =>
                {
                    dividend += g.GradeOne + g.GradeTwo + g.GradeThree + g.GradeFour;
                });

                courses.Add(new CourseHomeGetAllView()
                {
                    Id = c.Id,
                    Name = c.Name,
                    NumberOfTeachers = numberOfTeachers.Count(),
                    NumberOfStudents = numberOfStudents.Count(),
                    GradeAvarege = grades.Count() != 0 ? dividend / grades.Count() : 0,
                });
            });

            return courses;
        }

        public CoursesModel GetById(int Id)
        {
            return _universityDbContext.Courses.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(CourseUpdateByIdView Course)
        {
            if (Course == null)
                return false;

            CoursesModel courseModel = _universityDbContext.Courses.Where(c => c.Id == Course.Id).FirstOrDefault();

            if (courseModel == null)
                return false;

            courseModel.Name = !string.IsNullOrEmpty(Course.Name) ? Course.Name : courseModel.Name;

            _universityDbContext.Courses.Update(courseModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            CoursesModel courseModel = _universityDbContext.Courses.Where(c => c.Id == Id).FirstOrDefault();

            if (courseModel == null)
                return false;

            _universityDbContext.Attach(courseModel);
            _universityDbContext.Remove(courseModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
