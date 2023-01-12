using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class GradeAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public double? Value { get; set; }
    }
}
