using Backend.Models.Students;
using Backend.Models.Students.Students;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentsRepository _repository;

        public StudentsController(IStudentsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] StudentAddView student)
        {
            bool res = _repository.Add(student);

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

        [HttpGet("GetById")]
        public IActionResult GetById([Required] int Id)
        {
            StudentsModel student = _repository.GetById(Id);

            return Ok(student);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] StudentUpdateByIdView student)
        {
            bool res = _repository.UpdateById(student);

            if (res)
                return Ok("Student registration changed successfully!");
            else
                return Ok("Error when changing student registration!");
        }

        [HttpPost("DeleteById")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok("Student registration successfully deleted!");
            else
                return Ok("Error deleting student record!");
        }
    }
}
