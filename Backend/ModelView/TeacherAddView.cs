using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class TeacherAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double? Salary { get; set; }
    }
}
