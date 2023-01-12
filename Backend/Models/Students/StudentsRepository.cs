
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

        public bool UpdateStudentEnrollmentByRegistrationNumber(UpdateStudentEnrollmentByIdModel EnrollStudent)
        {
            if (EnrollStudent == null)
                return false;

            Students_SubjectsModel student_SubjectModel = _universityDbContext.Students_Subjects.Where(ss => ss.RegistrationNumber == EnrollStudent.RegistrationNumber).FirstOrDefault();

            if (student_SubjectModel == null)
                return false;

            student_SubjectModel.StudentId = EnrollStudent.StudentId ?? student_SubjectModel.StudentId;
            student_SubjectModel.SubjectId = EnrollStudent.SubjectId ?? student_SubjectModel.SubjectId;
            student_SubjectModel.GradeId = EnrollStudent.GradeId ?? student_SubjectModel.GradeId;
            student_SubjectModel.StudentsNavigation = EnrollStudent.StudentId != null ? _universityDbContext.Students.Where(s => s.Id == EnrollStudent.StudentId).FirstOrDefault() : student_SubjectModel.StudentsNavigation;
            student_SubjectModel.SubjectsNavigation = EnrollStudent.SubjectId != null ? _universityDbContext.Subjects.Where(s => s.Id == EnrollStudent.SubjectId).FirstOrDefault() : student_SubjectModel.SubjectsNavigation;
            student_SubjectModel.GradesNavigation = EnrollStudent.GradeId != null ? _universityDbContext.Grades.Where(g => g.Id == EnrollStudent.GradeId).FirstOrDefault() : student_SubjectModel.GradesNavigation;

            _universityDbContext.Students_Subjects.Update(student_SubjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteStudentEnrollmentByRegistrationNumber(int RegistrationNumber)
        {
            if (RegistrationNumber <= 0)
                return false;

            Students_SubjectsModel student_SubjectModel = _universityDbContext.Students_Subjects.Where(s => s.RegistrationNumber == RegistrationNumber).FirstOrDefault();

            if (student_SubjectModel == null)
                return false;

            _universityDbContext.Attach(student_SubjectModel);
            _universityDbContext.Remove(student_SubjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteStudentEnrollmentByStudentId(int StudentId)
        {
            if (StudentId <= 0)
                return false;

            List<Students_SubjectsModel> student_SubjectModel = _universityDbContext.Students_Subjects.Where(s => s.SubjectId == StudentId).ToList();

            if (!student_SubjectModel.Any())
                return false;

            student_SubjectModel.ForEach(ss =>
            {
                _universityDbContext.Attach(ss);
                _universityDbContext.Remove(ss);
            });

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
