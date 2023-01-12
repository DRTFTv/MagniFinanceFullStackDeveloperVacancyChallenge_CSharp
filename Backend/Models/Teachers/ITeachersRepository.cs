using Backend.ModelView;

namespace Backend.Models.Teachers
{
    public interface ITeachersRepository
    {
        bool Add(TeacherAddView teacher);
        IEnumerable<TeachersModel> GetAll();
        TeachersModel GetById(int Id);
        bool UpdateById(TeacherUpdateByIdView teacher);
        bool DeleteById(int Id);
    }
}
