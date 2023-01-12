using Backend.ModelView;

namespace Backend.Models.Subjects
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly UniversityDbContext _universityDbContext;

        public SubjectsRepository(UniversityDbContext universityDbContext)
        {
            _universityDbContext = universityDbContext;
        }

        public bool Add(SubjectAddView subject)
        {
            if (subject == null)
                return false;


            _universityDbContext.Subjects.Add(new SubjectsModel
            {
                Name = subject.Name,
                CourseId = subject.CourseId ?? 0,
                TeacherId = subject.TeacherId ?? 0,
            });

            _universityDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<SubjectsModel> GetAll()
        {
            return _universityDbContext.Subjects;
        }

        public SubjectsModel GetById(int Id)
        {
            return _universityDbContext.Subjects.Where(s => s.Id == Id).FirstOrDefault();
        }

        public bool UpdateById(SubjectUpdateByIdView subject)
        {
            if (subject == null)
                return false;

            SubjectsModel subjectModel = _universityDbContext.Subjects.Where(s => s.Id == subject.Id).FirstOrDefault();

            subjectModel.Name = !string.IsNullOrEmpty(subject.Name) ? subject.Name : subjectModel.Name;
            subjectModel.CourseId = subject.CourseId ?? subjectModel.CourseId;
            subjectModel.TeacherId = subject.TeacherId ?? subjectModel.TeacherId;

            _universityDbContext.Subjects.Update(subjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }

        public bool DeleteById(int Id)
        {
            if (Id <= 0)
                return false;

            SubjectsModel subjectModel = _universityDbContext.Subjects.Where(s => s.Id == Id).FirstOrDefault();

            _universityDbContext.Attach(subjectModel);
            _universityDbContext.Remove(subjectModel);

            _universityDbContext.SaveChanges();

            return true;
        }
    }
}
