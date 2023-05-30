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
        public async Task<ActionResult<List<Student>>> GetAllStudent()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("dbconn"));//sql connection
            IEnumerable<Student> students = await SelectAllStudents(connection);
            return Ok(students);
        }



        [HttpGet("{StudentId}")]
        public async Task<ActionResult<Student>> GetStudent(int StudentId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("dbconn"));//sql connection
            var student = await connection.QueryFirstAsync<Student>("select * from StudentsDetails where id=@Id",
                new { Id = StudentId });
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> PostStudent(Student student)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("dbconn"));//sql connection
            await connection.ExecuteAsync("insert into StudentsDetails (name, familyName, address,contactNumber) values (@Name, @FamilyName, @Address, @ContactNumber)", student);
            return Ok(SelectAllStudents(connection));
        }

        [HttpPut("{StudentId}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int StudentId, Student student)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("dbconn"));//sql connection
            await connection.ExecuteAsync("update StudentsDetails name=@Name, familyName= @FamilyName, address=@Address, contactNumber=@ContactNumber where id=@Id", new { Id = StudentId });
            return Ok(SelectAllStudents(connection));
        }


        [HttpDelete("{StudentId}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int StudentId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("dbconn"));//sql connection
            await connection.ExecuteAsync("Delete from StudentsDetails where id=@Id", new { Id = StudentId });
            return Ok(SelectAllStudents(connection));
        }

        private static async Task<IEnumerable<Student>> SelectAllStudents(SqlConnection connection)
        {
            return await connection.QueryAsync<Student>("select * from StudentsDetails");
        }
    }
}
