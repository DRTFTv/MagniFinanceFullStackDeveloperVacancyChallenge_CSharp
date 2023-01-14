using Backend.ModelView;
using System.Diagnostics;

namespace Backend.Models.Grades
{
    public class GradeRepository : IGradesRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public GradeRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public bool Add(GradeAddView Grade)
        {
            if (Grade == null)
                return false;


            _universityDbContext.Grades.Add(new GradesModel
            {
                GradeOne = Grade.GradeOne ?? 0,
                GradeTwo = Grade.GradeTwo ?? 0,
                GradeThree = Grade.GradeThree ?? 0,
                GradeFour = Grade.GradeFour ?? 0,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public int AddReturnId()
        {
            _universityDbContext.Grades.Add(new GradesModel
            {
                GradeOne = 0,
                GradeTwo = 0,
                GradeThree = 0,
                GradeFour = 0,
            });

            _universityDbContext.SaveChanges();

            return _universityDbContext.Grades.ToList().Last().Id;
        }

        public IEnumerable<GradesModel> GetAll()
        {
            return _universityDbContext.Grades;
        }

        public GradesModel GetById(int Id)
        {
            return _universityDbContext.Grades.Where(g => g.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(GradeUpdateByIdView Grade)
        {
            if (Grade == null)
                return false;

            GradesModel gradeModel = _universityDbContext.Grades.Where(g => g.Id == Grade.Id).FirstOrDefault();

            if (gradeModel == null)
                return false;

            gradeModel.GradeOne = Grade.GradeOne ?? gradeModel.GradeOne;
            gradeModel.GradeTwo = Grade.GradeTwo ?? gradeModel.GradeTwo;
            gradeModel.GradeThree = Grade.GradeThree ?? gradeModel.GradeThree;
            gradeModel.GradeFour = Grade.GradeFour ?? gradeModel.GradeFour;

            _universityDbContext.Grades.Update(gradeModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            GradesModel gradeModel = _universityDbContext.Grades.Where(g => g.Id == Id).FirstOrDefault();

            if (gradeModel == null)
                return false;

            _universityDbContext.Attach(gradeModel);
            _universityDbContext.Remove(gradeModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
