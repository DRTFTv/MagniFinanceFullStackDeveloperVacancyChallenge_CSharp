using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class StudentHomeGetAllView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public List<GradesForDiscipline> Grades { get; set; }
    }

    public class GradesForDiscipline
    {
        [Required(ErrorMessage = "{0} is required")]
        public string SubjectName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeOne { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeTwo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeThree { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeFour { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public double GradeAvarege { get; set; }
    }
}
