using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using backEnd.Models;

namespace backEnd.Controllers
{
    [ApiController]
    public class Learner_PlatformController : ControllerBase
    {
        private IConfiguration _configuration;
        public Learner_PlatformController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("get_learner")]
        public JsonResult get_learner()
        {
            string query = "SELECT * FROM LearnerBio";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("learner_platform");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        table.Load(myReader);
                    }
                }
            }

            return new JsonResult(table);
        }



        [HttpPost("add_learner")]
        public IActionResult AddLearner([FromBody] RegisteredLearner learner)
        {
            if (learner == null)
                return BadRequest(new { message = "Learner data is null" });

            string query = @"
        INSERT INTO RegisteredLearners
        (FirstName, MiddleName, LastName, DateOfBirth, Email, Cellphone)
        VALUES
        (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Email, @Cellphone)";

            string sqlDataSource = _configuration.GetConnectionString("learner_platform");

            using (SqlConnection conn = new SqlConnection(sqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", learner.FirstName ?? string.Empty);
                    cmd.Parameters.AddWithValue("@MiddleName", (object?)learner.MiddleName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", learner.LastName ?? string.Empty);
                    cmd.Parameters.AddWithValue("@DateOfBirth", learner.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Email", learner.Email ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Cellphone", learner.Cellphone ?? string.Empty);

                    cmd.ExecuteNonQuery();
                }
            }

            return Ok(new { message = "Learner added successfully" });

        }



    }
}
