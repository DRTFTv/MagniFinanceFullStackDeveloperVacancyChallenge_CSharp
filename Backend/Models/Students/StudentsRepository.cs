
using Backend.Models.Grades;
using Backend.Models.Students.Students;
using Backend.Models.Students_Subjects;
using Backend.ModelView;

namespace Backend.Models.Students
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly UniversityDbContext _universityDbContext;
        private IGradesRepository _grades;
        private IStudents_SubjectsRepository _students_subjects;

        public StudentsRepository(UniversityDbContext universityDbContext, IGradesRepository grades, IStudents_SubjectsRepository students_subjects)
        {
            _universityDbContext = universityDbContext;
            _grades = grades;
            _students_subjects = students_subjects;
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

        public IEnumerable<StudentHomeGetAllView> HomeGetAll()
        {
            List<StudentHomeGetAllView> students = new List<StudentHomeGetAllView>();

            _universityDbContext.Students.ToList().ForEach(c =>
            {
                List<GradesForDiscipline> gradesForDiscipline = new List<GradesForDiscipline>();

                List<Students_SubjectsModel> students_SubjectsModel = _students_subjects.GetAllByStudentId(c.Id).ToList();

                students_SubjectsModel.ForEach(ss =>
                {
                    GradesModel grade = _universityDbContext.Grades.Where(g => g.Id == ss.GradeId).FirstOrDefault();

                    gradesForDiscipline.Add(new GradesForDiscipline()
                    {
                        SubjectName = _universityDbContext.Subjects.Where(s => s.Id == ss.SubjectId).FirstOrDefault().Name,
                        GradeOne = grade.GradeOne,
                        GradeTwo = grade.GradeTwo,
                        GradeThree = grade.GradeThree,
                        GradeFour = grade.GradeFour,
                        GradeAvarege = (grade.GradeOne + grade.GradeTwo + grade.GradeThree + grade.GradeFour) / 4,
                    });
                });

                students.Add(new StudentHomeGetAllView()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Grades = gradesForDiscipline,
                });
            });

            return students;
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
            if (Id <= 0)
                return false;

            StudentsModel studentModel = _universityDbContext.Students.Where(s => s.Id == Id).FirstOrDefault();

            if (studentModel == null)
                return false;

            _universityDbContext.Attach(studentModel);
            _universityDbContext.Remove(studentModel);

            _universityDbContext.SaveChanges();

            return true;
        }        
    }
}
