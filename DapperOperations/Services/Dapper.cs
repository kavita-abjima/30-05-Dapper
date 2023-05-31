using DapperCrudOperations;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace DapperOperations.Services
{
    public class Dapper : IDapper
    {
        private readonly IConfiguration _config;

        private string Connectionstring = "dbconn";
        public Dapper(IConfiguration config)
        {
            _config = config;

        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            //student.AddedOn = DateTime.Now;
            var sql = "Insert into Products (Name,FamilyName,Address,ContactNumber) VALUES (@Name,@FamilyName,@Address,@ContactNumber)";
            using (var connection = new SqlConnection(_config.GetConnectionString("dbconn")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, student);
                return result;
            }
        }

        public async Task<Student> DeleteEmployeeAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_config.GetConnectionString("dbconn")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Student>> GetStudent()
        {
            //var sql = "SELECT * FROM StudentsDetails";
            //using (var connection = new SqlConnection(_config.GetConnectionString("dbconn")))
            //{
            //    connection.Open();
            //    var result = await connection.QueryAsync<Student>(sql);
            //    return result.ToList();
            //}
        }

        public async Task<Student> GetStudentById(int id)
        {
            var sql = "SELECT * FROM StudentsDetail WHERE Id = @Id";
            using (var connection = new SqlConnection(_config.GetConnectionString("dbconn")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Student>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            
            var sql = "UPDATE Products SET Name = @Name, FamilyName = @FamilyName, Address=@Address, ContactNumber = @contactNumber,  WHERE Id = @Id";
            using (var connection = new SqlConnection(_config.GetConnectionString("dbconn")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, student);
                return result;
            }
        }
    }
}
