using Backend.Models.Courses;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private ICoursesRepository _repository;

        public CoursesController(ICoursesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] CourseAddView Course)
        {
            bool res = _repository.Add(Course);

            if (res)
                return Ok("Successfully registered course!");
            else
                return Ok("Error registering course!");
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            IEnumerable<CoursesModel> courses = _repository.GetAll();

            return Ok(courses);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById([Required] int Id)
        {
            CoursesModel course = _repository.GetById(Id);

            return Ok(course);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] CourseUpdateByIdView Course)
        {
            bool res = _repository.UpdateById(Course);

            if (res)
                return Ok("Course registration changed successfully!");
            else
                return Ok("Error when changing course registration!");
        }

        [HttpDelete("DeleteById/{Id}")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok("Course registration successfully deleted!");
            else
                return Ok("Error deleting Course record!");
        }
    }
}
