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
        public IActionResult Add([FromForm] StudentAddView Student)
        {
            bool res = _repository.Add(Student);

            if (res)
                return Ok("Successfully registered student!");
            else
                return Ok("Error registering student!");
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            IEnumerable<StudentsModel> students = _repository.GetAll();

            return Ok(students);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById([Required] int Id)
        {
            StudentsModel student = _repository.GetById(Id);

            return Ok(student);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] StudentUpdateByIdView Student)
        {
            bool res = _repository.UpdateById(Student);

            if (res)
                return Ok("Student registration changed successfully!");
            else
                return Ok("Error when changing student registration!");
        }

        [HttpDelete("DeleteById/{Id}")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok("Student registration successfully deleted!");
            else
                return Ok("Error deleting student record!");
        }

        ///
        [HttpPost("AddEnrollStudent")]
        public IActionResult AddEnrollStudent([FromForm] EnrollStudentView EnrollStudent) {
            bool res = _repository.AddEnrollStudent(EnrollStudent);

            if (res)
                return Ok("Student enrolled successfully!");
            else
                return Ok("Error enrolling student!");
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
        public IActionResult UpdateStudentEnrollmentByRegistrationNumber([FromForm] UpdateStudentEnrollmentByIdModel EnrollStudent)
        {
            bool res = _repository.UpdateStudentEnrollmentByRegistrationNumber(EnrollStudent);

            if (res)
                return Ok("Student enrollment changed successfully!");
            else
                return Ok("Error when changing student registration!");
        }

        [HttpDelete("DeleteStudentEnrollmentByRegistrationNumber/{RegistrationNumber}")]
        public IActionResult DeleteStudentEnrollmentByRegistrationNumber([Required] int RegistrationNumber)
        {
            bool res = _repository.DeleteStudentEnrollmentByRegistrationNumber(RegistrationNumber);

            if (res)
                return Ok("Enrollment of deleted student successfully!");
            else
                return Ok("Error deleting student registration!");
        }

        [HttpDelete("DeleteStudentEnrollmentByStudentId/{StudentId}")]
        public IActionResult DeleteStudentEnrollmentByStudentId([Required] int StudentId)
        {
            bool res = _repository.DeleteStudentEnrollmentByStudentId(StudentId);

            if (res)
                return Ok("Enrollment of deleted student successfully!");
            else
                return Ok("Error deleting student registration!");
        }
    }
}
