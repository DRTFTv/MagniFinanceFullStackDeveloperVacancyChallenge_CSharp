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
        public IActionResult Add([FromBody] SubjectAddView Subject)
        {
            bool res = _repository.Add(Subject);

            if (res)
                return Ok(new ResponseModel() { Message = "Successfully registered subject!" });
            else
                return Ok(new ResponseModel() { Message = "Error registering subject!" });
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            IEnumerable<SubjectGetAllView> subjects = _repository.GetAll();

            return Ok(subjects);
        }

        [HttpGet("HomeGetAll")]
        public IActionResult HomeGetAll()
        {
            IEnumerable<SubjectHomeGetAllView> subjects = _repository.HomeGetAll();

            return Ok(subjects);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById([Required] int Id)
        {
            SubjectsModel subject = _repository.GetById(Id);

            return Ok(subject);
        }

        [HttpPut("UpdateById")]
        public IActionResult UpdateById([FromBody] SubjectUpdateByIdView Subject)
        {
            bool res = _repository.UpdateById(Subject);

            if (res)
                return Ok(new ResponseModel() { Message = "Subject registration changed successfully!" });
            else
                return Ok(new ResponseModel() { Message = "Error when changing subject registration!" });
        }

        [HttpDelete("DeleteById/{Id}")]
        public IActionResult DeleteById([Required] int Id)
        {
            bool res = _repository.DeleteById(Id);

            if (res)
                return Ok(new ResponseModel() { Message = "Subject registration successfully deleted!" });
            else
                return Ok(new ResponseModel() { Message = "Error deleting subject record!" });
        }
    }
}
