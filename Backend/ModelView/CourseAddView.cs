using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class CourseAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
