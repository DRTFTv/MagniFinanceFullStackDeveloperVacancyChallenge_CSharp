using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Backend.Models.Grades;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private IGradesRepository _repository;

        public GradesController(IGradesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] GradeAddView Grade)
        {
            bool res = _repository.Add(Grade);

            if (res)
                return Ok("Successfully registered grade!");
            else
                return Ok("Error registering grade!");
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            IEnumerable<GradesModel> grades = _repository.GetAll();

            return Ok(grades);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([Required] int Id)
        {
            GradesModel grade = _repository.GetById(Id);

            return Ok(grade);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] GradeUpdateByIdView Grade)
        {
            bool res = _repository.UpdateById(Grade);

            if (res)
                return Ok("Grade registration changed successfully!");
            else
                return Ok("Error when changing grade registration!");
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok("Grade registration successfully deleted!");
            else
                return Ok("Error deleting grade record!");
        }
    }
}
