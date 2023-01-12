using Backend.Models.Courses;
using Backend.Models.Teachers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Subjects
{
    [Table("subjects_tb")]
    public class SubjectsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("course_id")]
        public int? CourseId { get; set; }

        [Required]
        [ForeignKey("teacher_id")]
        public int? TeacherId { get; set; }

        [Required]
        public virtual CoursesModel CoursesNavigation { get; set; }

        [Required]
        public virtual TeachersModel TeachersNavigation { get; set; }
    }
}
