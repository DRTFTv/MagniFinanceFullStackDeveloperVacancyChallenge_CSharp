using Backend.Models.Courses;
using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Students_Subjects;
using Backend.Models.Subjects;
using Backend.Models.Teachers;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions options) : base(options) { }

        public DbSet<StudentsModel> Students { get; set; }

        public DbSet<TeachersModel> Teachers { get; set; }

        public DbSet<CoursesModel> Courses { get; set; }

        public DbSet<SubjectsModel> Subjects { get; set; }
        
        public DbSet<GradesModel> Grades { get; set; }

        public DbSet<Students_SubjectsModel> Students_Subjects { get; set; }
    }
}
