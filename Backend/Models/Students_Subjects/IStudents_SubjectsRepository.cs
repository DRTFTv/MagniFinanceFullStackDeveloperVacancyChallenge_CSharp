using Backend.ModelView;

namespace Backend.Models.Students_Subjects
{
    public interface IStudents_SubjectsRepository
    {
        bool Add(EnrollmentAddView Enrollment);
        IEnumerable<EnrollmentGetAllView> GetAll();
        Students_SubjectsModel GetByRegistrationNumber(int RegistrationNumber);
        IEnumerable<Students_SubjectsModel> GetAllByStudentId(int StudentId);
        bool UpdateByRegistrationNumber(UpdateStudentEnrollmentByIdModel Enrollment);
        bool DeleteByRegistrationNumber(int RegistrationNumber);
        bool DeleteByStudentId(int StudentId);
    }
}
