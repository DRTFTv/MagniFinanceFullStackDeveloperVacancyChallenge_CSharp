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
        public int RegistrationNumber { get; set; }

        [Required]
        [ForeignKey("student_id")]
        public int? StudentId { get; set; }

        [Required]
        [ForeignKey("subject_id")]
        public int? SubjectId { get; set; }

        [Required]
        [ForeignKey("grade_id")]
        public int? GradeId { get; set; }

        public virtual StudentsModel StudentsNavigation { get; set; }

        public virtual SubjectsModel SubjectsNavigation { get; set; }

        public virtual GradesModel GradesNavigation { get; set; }
    }
}
