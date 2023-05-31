using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperCrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IConfiguration _config;
        public StudentsController(IConfiguration config)
        {
            _config = config;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _config.StudentsDetails.GetStudent();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _config.StudentsDetails.GetStudentBy(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            var data = await _config.StudentsDetails.AddStudentAsync(student);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _config.StudentsDetails.DeleteStudentAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            var data = await _config.StudentsDetails.UpdateStudentAsync(student);
            return Ok(data);
        }
    }
}
