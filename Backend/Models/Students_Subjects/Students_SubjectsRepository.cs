using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Subjects;
using Backend.ModelView;
using static Backend.ModelView.EnrollmentGetAllView;

namespace Backend.Models.Students_Subjects
{
    public class Students_SubjectsRepository : IStudents_SubjectsRepository
    {
        private readonly UniversityDbContext _universityDbContext;
        private IGradesRepository _grades;

        public Students_SubjectsRepository(UniversityDbContext universityDbContext, IGradesRepository grades)
        {
            _universityDbContext = universityDbContext;
            _grades = grades;
        }

        public bool Add(EnrollmentAddView Enrollment)
        {
            if (Enrollment == null)
                return false;

            int gradeId = _grades.AddReturnId();

            StudentsModel studentsModel = _universityDbContext.Students.Where(s => s.Id == Enrollment.StudentId).FirstOrDefault();
            SubjectsModel subjectsModel = _universityDbContext.Subjects.Where(s => s.Id == Enrollment.SubjectId).FirstOrDefault();
            GradesModel gradesModel = _universityDbContext.Grades.Where(s => s.Id == gradeId).FirstOrDefault();

            if (studentsModel == null || subjectsModel == null || gradesModel == null)
                return false;

            _universityDbContext.Students_Subjects.Add(new Students_SubjectsModel
            {
                StudentId = Enrollment.StudentId,
                SubjectId = Enrollment.SubjectId,
                GradeId = gradeId,
                StudentsNavigation = studentsModel,
                SubjectsNavigation = subjectsModel,
                GradesNavigation = _universityDbContext.Grades.Where(g => g.Id == gradeId).FirstOrDefault()
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<EnrollmentGetAllView> GetAll()
        {
            List<EnrollmentGetAllView> enrollments = new List<EnrollmentGetAllView>();

            _universityDbContext.Students_Subjects.ToList().ForEach(ss =>
            {
                GradesModel grade = _universityDbContext.Grades.Where(g => g.Id == ss.GradeId).FirstOrDefault();

                GradeForDiscipline gradeForDiscipline = new GradeForDiscipline {
                    SubjectId = ss.SubjectId ?? 0,
                    SubjectName = _universityDbContext.Subjects.Where(s => s.Id == ss.SubjectId).FirstOrDefault().Name,
                    GradeId = ss.GradeId ?? 0,
                    GradeOne = grade.GradeOne,
                    GradeTwo = grade.GradeTwo,
                    GradeThree = grade.GradeThree,
                    GradeFour = grade.GradeFour,
                    GradeAvarege = (grade.GradeOne + grade.GradeTwo + grade.GradeThree + grade.GradeFour) / 4,
                };

                enrollments.Add(new EnrollmentGetAllView
                {
                    RegistrationNumber = ss.RegistrationNumber,
                    StudentId = ss.StudentId ?? 0,
                    StudentName = _universityDbContext.Students.Where(s => s.Id == ss.StudentId).FirstOrDefault().Name,
                    Grade = gradeForDiscipline 
                });
            });

            return enrollments;
        }

        public Students_SubjectsModel GetByRegistrationNumber(int RegistrationNumber)
        {
            return _universityDbContext.Students_Subjects.Where(s => s.RegistrationNumber == RegistrationNumber).FirstOrDefault();
        }

        public IEnumerable<Students_SubjectsModel> GetAllByStudentId(int StudentId)
        {
            return _universityDbContext.Students_Subjects.Where(s => s.StudentId == StudentId);
        }

        public bool UpdateByRegistrationNumber(UpdateStudentEnrollmentByIdModel Enrollment)
        {
            if (Enrollment == null)
                return false;

            Students_SubjectsModel student_SubjectModel = _universityDbContext.Students_Subjects.Where(ss => ss.RegistrationNumber == Enrollment.RegistrationNumber).FirstOrDefault();

            if (student_SubjectModel == null)
                return false;

            student_SubjectModel.StudentId = Enrollment.StudentId ?? student_SubjectModel.StudentId;
            student_SubjectModel.SubjectId = Enrollment.SubjectId ?? student_SubjectModel.SubjectId;
            student_SubjectModel.GradeId = Enrollment.GradeId ?? student_SubjectModel.GradeId;
            student_SubjectModel.StudentsNavigation = Enrollment.StudentId != null ? _universityDbContext.Students.Where(s => s.Id == Enrollment.StudentId).FirstOrDefault() : student_SubjectModel.StudentsNavigation;
            student_SubjectModel.SubjectsNavigation = Enrollment.SubjectId != null ? _universityDbContext.Subjects.Where(s => s.Id == Enrollment.SubjectId).FirstOrDefault() : student_SubjectModel.SubjectsNavigation;
            student_SubjectModel.GradesNavigation = Enrollment.GradeId != null ? _universityDbContext.Grades.Where(g => g.Id == Enrollment.GradeId).FirstOrDefault() : student_SubjectModel.GradesNavigation;

            _universityDbContext.Students_Subjects.Update(student_SubjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteByRegistrationNumber(int RegistrationNumber)
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

        public bool DeleteByStudentId(int StudentId)
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
