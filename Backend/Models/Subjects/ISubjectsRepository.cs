using Backend.ModelView;

namespace Backend.Models.Subjects
{
    public interface ISubjectsRepository
    {
        bool Add(SubjectAddView student);
        IEnumerable<SubjectsModel> GetAll();
        SubjectsModel GetById(int Id);
        bool UpdateById(SubjectUpdateByIdView student);
        bool DeleteById(int Id);
    }
}
