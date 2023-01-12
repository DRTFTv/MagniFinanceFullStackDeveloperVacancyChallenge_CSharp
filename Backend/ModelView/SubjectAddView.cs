using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class SubjectAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? CourseId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int? TeacherId { get; set; }
    }
}
