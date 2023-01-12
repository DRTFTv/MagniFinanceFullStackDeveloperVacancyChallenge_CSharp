using Backend.ModelView;

namespace Backend.Models.Teachers
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public TeachersRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public bool Add(TeacherAddView teacher)
        {
            if (teacher == null)
                return false;


            _universityDbContext.Teachers.Add(new TeachersModel
            {
                Name = teacher.Name,
                BirthDate = teacher.BirthDate ?? DateTime.Now,
                Salary = teacher.Salary ?? 0,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<TeachersModel> GetAll()
        {
            return _universityDbContext.Teachers;
        }

        public TeachersModel GetById(int Id)
        {
            return _universityDbContext.Teachers.Where(s => s.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(TeacherUpdateByIdView teacher)
        {
            if (teacher == null)
                return false;

            TeachersModel teacherModel = _universityDbContext.Teachers.Where(s => s.Id == teacher.Id).FirstOrDefault();

            teacherModel.Name = !string.IsNullOrEmpty(teacher.Name) ? teacher.Name : teacherModel.Name;
            teacherModel.BirthDate = teacher.BirthDate ?? teacherModel.BirthDate;
            teacherModel.Salary = teacher.Salary ?? teacherModel.Salary;

            _universityDbContext.Teachers.Update(teacherModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            TeachersModel teacherModel = _universityDbContext.Teachers.Where(s => s.Id == Id).FirstOrDefault();

            _universityDbContext.Attach(teacherModel);
            _universityDbContext.Remove(teacherModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
