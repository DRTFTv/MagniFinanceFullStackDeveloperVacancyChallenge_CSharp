using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class CourseUpdateByIdView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
    }
}
