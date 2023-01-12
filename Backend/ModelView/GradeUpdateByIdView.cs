using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class GradeUpdateByIdView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double? Value { get; set; }
    }
}
