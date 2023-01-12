using Backend.Models.Students_Subjects;
using Backend.ModelView;

namespace Backend.Models.Students.Students
{
    public interface IStudentsRepository
    {
        bool Add(StudentAddView Student);
        IEnumerable<StudentsModel> GetAll();
        StudentsModel GetById(int Id);
        bool UpdateById(StudentUpdateByIdView Student);
        bool DeleteById(int Id);

        ///
        bool AddEnrollStudent(EnrollStudentView EnrollStudent);
        IEnumerable<Students_SubjectsModel> GetAllStudentEnrollments();
        Students_SubjectsModel GetStudentEnrollmentByRegistrationNumber(int RegistrationNumber);
        IEnumerable<Students_SubjectsModel> GetAllStudentEnrollmentsByStudentId(int StudentId);
        bool UpdateStudentEnrollmentByRegistrationNumber(UpdateStudentEnrollmentByIdModel EnrollStudent);
        bool DeleteStudentEnrollmentByRegistrationNumber(int RegistrationNumber);
        bool DeleteStudentEnrollmentByStudentId(int StudentId);
    }
}
