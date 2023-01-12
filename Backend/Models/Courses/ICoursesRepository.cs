using Backend.ModelView;

namespace Backend.Models.Courses
{
    public interface ICoursesRepository
    {
        bool Add(CourseAddView Course);
        IEnumerable<CoursesModel> GetAll();
        CoursesModel GetById(int Id);
        bool UpdateById(CourseUpdateByIdView Course);
        bool DeleteById(int Id);
    }
}
