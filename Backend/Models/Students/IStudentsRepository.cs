using Backend.ModelView;

namespace Backend.Models.Students.Students
{
    public interface IStudentsRepository
    {
        bool Add(StudentAddView student);
        IEnumerable<StudentsModel> GetAll();
        StudentsModel GetById(int Id);
        bool UpdateById(StudentUpdateByIdView student);
        bool DeleteById(int Id);
    }
}
