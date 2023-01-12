
using Backend.Models.Grades;
using Backend.Models.Students.Students;
using Backend.Models.Students_Subjects;
using Backend.Models.Subjects;
using Backend.ModelView;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Students
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly UniversityDbContext _universityDbContext;
        private IGradesRepository _grades;

        public StudentsRepository(UniversityDbContext universityDbContext, IGradesRepository grades) {
            _universityDbContext = universityDbContext;
            _grades = grades;
        }

        public bool Add(StudentAddView Student)
        {
            if (Student == null)
                return false;


            _universityDbContext.Students.Add(new StudentsModel
            {
                Name = Student.Name,
                BirthDate = Student.BirthDate ?? DateTime.Now,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<StudentsModel> GetAll()
        {
            return _universityDbContext.Students;
        }

        public StudentsModel GetById(int Id)
        {
            return _universityDbContext.Students.Where(s => s.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(StudentUpdateByIdView Student)
        {
            if (Student == null)
                return false;

            StudentsModel studentModel = _universityDbContext.Students.Where(s => s.Id == Student.Id).FirstOrDefault();

            if (studentModel == null)
                return false;

            studentModel.Name = !string.IsNullOrEmpty(Student.Name) ? Student.Name : studentModel.Name;
            studentModel.BirthDate = Student.BirthDate ?? studentModel.BirthDate;

            _universityDbContext.Students.Update(studentModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if(Id <= 0)
                return false;

            StudentsModel studentModel = _universityDbContext.Students.Where(s => s.Id == Id).FirstOrDefault();

            if (studentModel == null)
                return false;

            _universityDbContext.Attach(studentModel);
            _universityDbContext.Remove(studentModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        ///
        public bool AddEnrollStudent(EnrollStudentView EnrollStudent)
        {
            if (EnrollStudent == null)
                return false;

            int gradeId = _grades.AddReturnId();

            _universityDbContext.Students_Subjects.Add(new Students_SubjectsModel
            {
                StudentId = EnrollStudent.StudentId,
                SubjectId = EnrollStudent.SubjectId,
                GradeId = gradeId,
                StudentsNavigation = _universityDbContext.Students.Where(s => s.Id == EnrollStudent.StudentId).FirstOrDefault(),
                SubjectsNavigation = _universityDbContext.Subjects.Where(s => s.Id == EnrollStudent.SubjectId).FirstOrDefault(),
                GradesNavigation = _universityDbContext.Grades.Where(g => g.Id == gradeId).FirstOrDefault()
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Students_SubjectsModel> GetAllStudentEnrollments()
        {
            return _universityDbContext.Students_Subjects;
        }

        public Students_SubjectsModel GetStudentEnrollmentByRegistrationNumber(int RegistrationNumber)
        {
            return _universityDbContext.Students_Subjects.Where(s => s.RegistrationNumber == RegistrationNumber).FirstOrDefault();
        }

        public IEnumerable<Students_SubjectsModel> GetAllStudentEnrollmentsByStudentId(int StudentId)
        {
            return _universityDbContext.Students_Subjects.Where(s => s.StudentId == StudentId);
        }

        public bool UpdateStudentEnrollmentById(UpdateStudentEnrollmentByIdModel EnrollStudent)
        {
            if (EnrollStudent == null)
                return false;

            Students_SubjectsModel students_SubjectsModel = _universityDbContext.Students_Subjects.Where(ss => ss.RegistrationNumber == EnrollStudent.RegistrationNumber).FirstOrDefault();

            if (students_SubjectsModel == null)
                return false;

            students_SubjectsModel.StudentId = EnrollStudent.StudentId ?? students_SubjectsModel.StudentId;
            students_SubjectsModel.SubjectId = EnrollStudent.SubjectId ?? students_SubjectsModel.SubjectId;
            students_SubjectsModel.GradeId = EnrollStudent.GradeId ?? students_SubjectsModel.GradeId;
            students_SubjectsModel.StudentsNavigation = EnrollStudent.StudentId != null ? _universityDbContext.Students.Where(s => s.Id == EnrollStudent.StudentId).FirstOrDefault() : students_SubjectsModel.StudentsNavigation;
            students_SubjectsModel.SubjectsNavigation = EnrollStudent.SubjectId != null ? _universityDbContext.Subjects.Where(s => s.Id == EnrollStudent.SubjectId).FirstOrDefault() : students_SubjectsModel.SubjectsNavigation;
            students_SubjectsModel.GradesNavigation = EnrollStudent.GradeId != null ? _universityDbContext.Grades.Where(g => g.Id == EnrollStudent.GradeId).FirstOrDefault() : students_SubjectsModel.GradesNavigation;

            _universityDbContext.Students_Subjects.Update(students_SubjectsModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
