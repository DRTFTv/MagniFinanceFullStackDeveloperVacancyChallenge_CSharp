using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Students.Students;
using Backend.Models.Students_Subjects;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentsRepository _repository;

        public StudentsController(IStudentsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StudentAddView Student)
        {
            bool res = _repository.Add(Student);


            if (res)
                return Ok(new ResponseModel() { Message = "Successfully registered student!" });
            else
                return Ok(new ResponseModel() { Message = "Error registering student!" });

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<StudentsModel> students = _repository.GetAll();

            return Ok(students);
        }

        [HttpGet("HomeGetAll")]
        public IActionResult HomeGetAll()
        {
            IEnumerable<StudentHomeGetAllView> students = _repository.HomeGetAll();

            return Ok(students);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById([Required] int Id)
        {
            StudentsModel student = _repository.GetById(Id);

            return Ok(student);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromBody] StudentUpdateByIdView Student)
        {
            bool res = _repository.UpdateById(Student);

            if (res)
                return Ok(new ResponseModel() { Message = "Student registration changed successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error when changing student registration!" });
        }

        [HttpDelete("DeleteById/{Id}")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok(new ResponseModel() { Message = "Student registration successfully deleted!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting student record!" });
        }

        ///
        [HttpPost("AddEnrollStudent")]
        public IActionResult AddEnrollStudent([FromBody] EnrollStudentView EnrollStudent)
        {
            bool res = _repository.AddEnrollStudent(EnrollStudent);

            if (res)
                return Ok(new ResponseModel() { Message = "Student enrolled successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error enrolling student!" });
        }

        [HttpGet("GetAllStudentEnrollments")]
        public IActionResult GetAllStudentEnrollments()
        {
            IEnumerable<Students_SubjectsModel> studentEnrollments = _repository.GetAllStudentEnrollments();

            return Ok(studentEnrollments);
        }

        [HttpGet("GetStudentEnrollmentByRegistrationNumber/{RegistrationNumber}")]
        public IActionResult GetStudentEnrollmentByRegistrationNumber([Required] int RegistrationNumber)
        {
            Students_SubjectsModel studentEnrollment = _repository.GetStudentEnrollmentByRegistrationNumber(RegistrationNumber);

            return Ok(studentEnrollment);
        }

        [HttpGet("GetAllStudentEnrollmentsByStudentId/{StudentId}")]
        public IActionResult GetAllStudentEnrollmentsByStudentId([Required] int StudentId)
        {
            IEnumerable<Students_SubjectsModel> studentEnrollments = _repository.GetAllStudentEnrollmentsByStudentId(StudentId);

            return Ok(studentEnrollments);
        }


        [HttpPut("UpdateStudentEnrollmentByRegistrationNumber")]
        public IActionResult UpdateStudentEnrollmentByRegistrationNumber([FromBody] UpdateStudentEnrollmentByIdModel EnrollStudent)
        {
            bool res = _repository.UpdateStudentEnrollmentByRegistrationNumber(EnrollStudent);

            if (res)
                return Ok(new ResponseModel() { Message = "Student enrollment changed successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error when changing student registration!" });
        }

        [HttpDelete("DeleteStudentEnrollmentByRegistrationNumber/{RegistrationNumber}")]
        public IActionResult DeleteStudentEnrollmentByRegistrationNumber([Required] int RegistrationNumber)
        {
            bool res = _repository.DeleteStudentEnrollmentByRegistrationNumber(RegistrationNumber);

            if (res)
                return Ok(new ResponseModel() { Message = "Enrollment of deleted student successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting student registration!" });
        }

        [HttpDelete("DeleteStudentEnrollmentByStudentId/{StudentId}")]
        public IActionResult DeleteStudentEnrollmentByStudentId([Required] int StudentId)
        {
            bool res = _repository.DeleteStudentEnrollmentByStudentId(StudentId);

            if (res)
                return Ok(new ResponseModel() { Message = "Enrollment of deleted student successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting student registration!" });
        }
    }
}
