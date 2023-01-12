using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class UpdateStudentEnrollmentByIdModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public int? RegistrationNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? StudentId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? SubjectId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? GradeId { get; set; }
    }
}
