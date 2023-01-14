using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class GradeAddView
    {
        [Required(ErrorMessage = "{0} is required")]
        public double? GradeOne { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double? GradeTwo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double? GradeThree { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double? GradeFour { get; set; }
    }
}
