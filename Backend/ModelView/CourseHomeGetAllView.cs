using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class CourseHomeGetAllView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int NumberOfTeachers { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int NumberOfStudents { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeAvarege { get; set; }

    }
}
