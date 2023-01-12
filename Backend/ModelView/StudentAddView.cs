using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class StudentAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime? BirthDate { get; set; }
    }
}
