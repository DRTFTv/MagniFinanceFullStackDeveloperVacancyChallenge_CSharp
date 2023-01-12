using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.Grades
{
    [Table("grades_tb")]
    public class GradesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
