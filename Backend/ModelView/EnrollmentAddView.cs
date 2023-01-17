using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Subjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class EnrollmentAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int? StudentId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? SubjectId { get; set; }
    }
}
