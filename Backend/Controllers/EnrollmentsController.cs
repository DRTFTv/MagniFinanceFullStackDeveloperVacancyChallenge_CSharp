using Backend.Models.Students.Students;
using Backend.Models.Students_Subjects;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private IStudents_SubjectsRepository _repository;

        public EnrollmentsController(IStudents_SubjectsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] EnrollmentAddView Enrollment)
        {
            bool res = _repository.Add(Enrollment);

            if (res)
                return Ok(new ResponseModel() { Message = "Student enrolled successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error enrolling student!" });
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<EnrollmentGetAllView> studentEnrollments = _repository.GetAll();

            return Ok(studentEnrollments);
        }

        [HttpGet("GetByRegistrationNumber/{RegistrationNumber}")]
        public IActionResult GetByRegistrationNumber([Required] int RegistrationNumber)
        {
            Students_SubjectsModel studentEnrollment = _repository.GetByRegistrationNumber(RegistrationNumber);

            return Ok(studentEnrollment);
        }

        [HttpGet("GetAllByStudentId/{StudentId}")]
        public IActionResult GetAllByStudentId([Required] int StudentId)
        {
            IEnumerable<Students_SubjectsModel> studentEnrollments = _repository.GetAllByStudentId(StudentId);

            return Ok(studentEnrollments);
        }


        [HttpPut("UpdateByRegistrationNumber")]
        public IActionResult UpdateByRegistrationNumber([FromBody] UpdateStudentEnrollmentByIdModel Enrollment)
        {
            bool res = _repository.UpdateByRegistrationNumber(Enrollment);

            if (res)
                return Ok(new ResponseModel() { Message = "Student enrollment changed successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error when changing student registration!" });
        }

        [HttpDelete("DeleteByRegistrationNumber/{RegistrationNumber}")]
        public IActionResult DeleteByRegistrationNumber([Required] int RegistrationNumber)
        {
            bool res = _repository.DeleteByRegistrationNumber(RegistrationNumber);

            if (res)
                return Ok(new ResponseModel() { Message = "Enrollment of deleted student successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting student registration!" });
        }

        [HttpDelete("DeleteByStudentId/{StudentId}")]
        public IActionResult DeleteByStudentId([Required] int StudentId)
        {
            bool res = _repository.DeleteByStudentId(StudentId);

            if (res)
                return Ok(new ResponseModel() { Message = "Enrollment of deleted student successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting student registration!" });
        }
    }
}
