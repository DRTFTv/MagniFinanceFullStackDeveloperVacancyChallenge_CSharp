using Backend.Models.Students;
using Backend.Models.Students.Students;
using Backend.Models.Teachers;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private ITeachersRepository _repository;

        public TeachersController(ITeachersRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] TeacherAddView Teacher)
        {
            bool res = _repository.Add(Teacher);

            if (res)
                return Ok("Successfully registered teacher!");
            else
                return Ok("Error registering teacher!");
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            IEnumerable<TeachersModel> teachers = _repository.GetAll();

            return Ok(teachers);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([Required] int Id)
        {
            TeachersModel teacher = _repository.GetById(Id);

            return Ok(teacher);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] TeacherUpdateByIdView Teacher)
        {
            bool res = _repository.UpdateById(Teacher);

            if (res)
                return Ok("Teacher registration changed successfully!");
            else
                return Ok("Error when changing teacher registration!");
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok("Teacher registration successfully deleted!");
            else
                return Ok("Error deleting teacher record!");
        }
    }
}
