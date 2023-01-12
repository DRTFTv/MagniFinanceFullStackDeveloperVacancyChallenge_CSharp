
using Backend.Models.Students.Students;
using Backend.ModelView;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models.Students
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public StudentsRepository(UniversityDbContext universityDbContext) {
            _universityDbContext = universityDbContext;
        }

        public bool Add(StudentAddView student)
        {
            if (student == null)
                return false;


            _universityDbContext.Students.Add(new StudentsModel
            {
                Name = student.Name,
                BirthDate = student.BirthDate ?? DateTime.Now,
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

        public bool UpdateById(StudentUpdateByIdView student)
        {
            if (student == null)
                return false;

            StudentsModel studentModel = _universityDbContext.Students.Where(s => s.Id == student.Id).FirstOrDefault();

            studentModel.Name = !string.IsNullOrEmpty(student.Name) ? student.Name : studentModel.Name;
            studentModel.BirthDate = student.BirthDate ?? studentModel.BirthDate;

            _universityDbContext.Students.Update(studentModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if(Id <= 0)
                return false;

            StudentsModel studentModel = _universityDbContext.Students.Where(s => s.Id == Id).FirstOrDefault();

            _universityDbContext.Attach(studentModel);
            _universityDbContext.Remove(studentModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
