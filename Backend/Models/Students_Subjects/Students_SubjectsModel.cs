using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Subjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Students_Subjects
{
    [Table("students_subjects_tb")]
    public class Students_SubjectsModel
    {
        [Key]
        public int registrationNumber { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int GradeId { get; set; }

        public virtual StudentsModel StudentsNavigation { get; set; }

        public virtual SubjectsModel SubjectsNavigation { get; set; }

        public virtual GradesModel GradesNavigation { get; set; }
    }
}
