using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class SubjectHomeGetAllView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime TeacherBirthDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double TeacherSalary { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int NumberOfStudents { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeAvarege { get; set; }
    }
}
