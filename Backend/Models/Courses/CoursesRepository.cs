using Backend.Models.Students;
using Backend.ModelView;

namespace Backend.Models.Courses
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public CoursesRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public bool Add(CourseAddView course)
        {
            if (course == null)
                return false;


            _universityDbContext.Courses.Add(new CoursesModel
            {
                Name = course.Name,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<CoursesModel> GetAll()
        {
            return _universityDbContext.Courses;
        }

        public CoursesModel GetById(int Id)
        {
            return _universityDbContext.Courses.Where(s => s.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(CourseUpdateByIdView course)
        {
            if (course == null)
                return false;

            CoursesModel courseModel = _universityDbContext.Courses.Where(s => s.Id == course.Id).FirstOrDefault();

            courseModel.Name = !string.IsNullOrEmpty(course.Name) ? course.Name : courseModel.Name;

            _universityDbContext.Courses.Update(courseModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            CoursesModel courseModel = _universityDbContext.Courses.Where(s => s.Id == Id).FirstOrDefault();

            _universityDbContext.Attach(courseModel);
            _universityDbContext.Remove(courseModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
