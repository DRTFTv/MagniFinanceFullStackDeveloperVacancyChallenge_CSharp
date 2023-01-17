using Backend.Models.Students_Subjects;
using Backend.ModelView;

namespace Backend.Models.Students.Students
{
    public interface IStudentsRepository
    {
        bool Add(StudentAddView Student);
        IEnumerable<StudentsModel> GetAll();
        IEnumerable<StudentHomeGetAllView> HomeGetAll();
        StudentsModel GetById(int Id);
        bool UpdateById(StudentUpdateByIdView Student);
        bool DeleteById(int Id);
    }
}
