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
        public IActionResult Add([FromBody] TeacherAddView Teacher)
        {
            bool res = _repository.Add(Teacher);

            if (res)
                return Ok(new ResponseModel() { Message = "Successfully registered teacher!" });
            else
                return Ok(new ResponseModel() { Message = "Error registering teacher!" });
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<TeachersModel> teachers = _repository.GetAll();

            return Ok(teachers);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById([Required] int Id)
        {
            TeachersModel teacher = _repository.GetById(Id);

            return Ok(teacher);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromBody] TeacherUpdateByIdView Teacher)
        {
            bool res = _repository.UpdateById(Teacher);

            if (res)
                return Ok(new ResponseModel() { Message = "Teacher registration changed successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error when changing teacher registration!" });
        }

        [HttpDelete("DeleteById/{Id}")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok(new ResponseModel() { Message = "Teacher registration successfully deleted!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting teacher record!" });
        }
    }
}
