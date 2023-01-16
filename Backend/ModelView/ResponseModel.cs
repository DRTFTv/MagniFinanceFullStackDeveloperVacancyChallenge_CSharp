using System.ComponentModel.DataAnnotations;

namespace Backend.ModelView
{
    public class ResponseModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Message { get; set; }
    }
}
