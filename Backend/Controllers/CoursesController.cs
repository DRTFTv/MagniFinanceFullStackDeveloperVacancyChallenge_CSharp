using Backend.Models.Courses;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private ICoursesRepository _repository;

        public CoursesController(ICoursesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] CourseAddView course)
        {
            bool res = _repository.Add(course);

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

        [HttpGet("GetById")]
        public IActionResult GetById([Required] int Id)
        {
            CoursesModel course = _repository.GetById(Id);

            return Ok(course);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] CourseUpdateByIdView course)
        {
            bool res = _repository.UpdateById(course);

            if (res)
                return Ok("Course registration changed successfully!");
            else
                return Ok("Error when changing course registration!");
        }

        [HttpPost("DeleteById")]
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
