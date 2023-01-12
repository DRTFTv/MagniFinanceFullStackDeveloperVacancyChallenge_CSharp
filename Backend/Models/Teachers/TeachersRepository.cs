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

        public bool Add(TeacherAddView Teacher)
        {
            if (Teacher == null)
                return false;


            _universityDbContext.Teachers.Add(new TeachersModel
            {
                Name = Teacher.Name,
                BirthDate = Teacher.BirthDate ?? DateTime.Now,
                Salary = Teacher.Salary ?? 0,
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

        public bool UpdateById(TeacherUpdateByIdView Teacher)
        {
            if (Teacher == null)
                return false;

            TeachersModel teacherModel = _universityDbContext.Teachers.Where(s => s.Id == Teacher.Id).FirstOrDefault();

            if(teacherModel == null)
                return false;

            teacherModel.Name = !string.IsNullOrEmpty(Teacher.Name) ? Teacher.Name : teacherModel.Name;
            teacherModel.BirthDate = Teacher.BirthDate ?? teacherModel.BirthDate;
            teacherModel.Salary = Teacher.Salary ?? teacherModel.Salary;

            _universityDbContext.Teachers.Update(teacherModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            TeachersModel teacherModel = _universityDbContext.Teachers.Where(s => s.Id == Id).FirstOrDefault();

            if (teacherModel == null)
                return false;

            _universityDbContext.Attach(teacherModel);
            _universityDbContext.Remove(teacherModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
