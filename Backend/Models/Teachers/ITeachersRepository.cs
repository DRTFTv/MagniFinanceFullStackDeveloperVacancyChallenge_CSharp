using Backend.ModelView;

namespace Backend.Models.Teachers
{
    public interface ITeachersRepository
    {
        bool Add(TeacherAddView Teacher);
        IEnumerable<TeachersModel> GetAll();
        TeachersModel GetById(int Id);
        bool UpdateById(TeacherUpdateByIdView Teacher);
        bool DeleteById(int Id);
    }
}
