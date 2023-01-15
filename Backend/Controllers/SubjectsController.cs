using Backend.Models.Subjects;
using Backend.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private ISubjectsRepository _repository;

        public SubjectsController(ISubjectsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] SubjectAddView Subject)
        {
            bool res = _repository.Add(Subject);

            if (res)
                return Ok("Successfully registered subject!");
            else
                return Ok("Error registering subject!");
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            IEnumerable<SubjectsModel> subjects = _repository.GetAll();

            return Ok(subjects);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById([Required] int Id)
        {
            SubjectsModel subject = _repository.GetById(Id);

            return Ok(subject);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromForm] SubjectUpdateByIdView Subject)
        {
            bool res = _repository.UpdateById(Subject);

            if (res)
                return Ok("Subject registration changed successfully!");
            else
                return Ok("Error when changing subject registration!");
        }

        [HttpDelete("DeleteById/{Id}")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok("Subject registration successfully deleted!");
            else
                return Ok("Error deleting subject record!");
        }
    }
}
