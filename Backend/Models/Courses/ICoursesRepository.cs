using Backend.ModelView;

namespace Backend.Models.Courses
{
    public interface ICoursesRepository
    {
        bool Add(CourseAddView course);
        IEnumerable<CoursesModel> GetAll();
        CoursesModel GetById(int Id);
        bool UpdateById(CourseUpdateByIdView course);
        bool DeleteById(int Id);
    }
}
