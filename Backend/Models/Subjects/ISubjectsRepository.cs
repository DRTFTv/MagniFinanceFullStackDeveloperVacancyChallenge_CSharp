using Backend.ModelView;

namespace Backend.Models.Subjects
{
    public interface ISubjectsRepository
    {
        bool Add(SubjectAddView Student);
        IEnumerable<SubjectsModel> GetAll();
        SubjectsModel GetById(int Id);
        bool UpdateById(SubjectUpdateByIdView Student);
        bool DeleteById(int Id);
    }
}
