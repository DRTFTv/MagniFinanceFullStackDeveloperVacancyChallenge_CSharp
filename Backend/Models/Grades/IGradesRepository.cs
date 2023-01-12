using Backend.Models.Students;
using Backend.ModelView;

namespace Backend.Models.Grades
{
    public interface IGradesRepository
    {
        bool Add(GradeAddView Grade);
        int AddReturnId();
        IEnumerable<GradesModel> GetAll();
        GradesModel GetById(int Id);
        bool UpdateById(GradeUpdateByIdView Grade);
        bool DeleteById(int Id);
    }
}
