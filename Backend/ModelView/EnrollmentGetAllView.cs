using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class EnrollmentGetAllView
    {
        [Required(ErrorMessage = "{0} is required")]
        public int RegistrationNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public GradeForDiscipline Grade { get; set; }

        public class GradeForDiscipline
        {
            [Required(ErrorMessage = "{0} is required")]
            public int SubjectId { get; set; }

            [Required(ErrorMessage = "{0} is required")]
            public string SubjectName { get; set; }

            [Required(ErrorMessage = "{0} is required")]
            public double GradeId { get; set; }

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
}
