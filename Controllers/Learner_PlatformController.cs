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
        public JsonResult add_learner(LearnerBio learner)
        {
            string query = @"
            INSERT INTO LearnerBio 
            (FirstName, MiddleName, LastName, Gender, DateofBirth, IDNumber, Email, Cell, Country, Province, City, SchoolName, Grade, Stream) 
            VALUES 
            (@FirstName, @MiddleName, @LastName, @Gender, @DateofBirth, @IDNumber, @Email, @Cell, @Country, @Province, @City, @SchoolName, @Grade, @Stream)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("learner_platform");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", learner.FirstName);
                    myCommand.Parameters.AddWithValue("@MiddleName", (object)learner.MiddleName ?? DBNull.Value);
                    myCommand.Parameters.AddWithValue("@LastName", learner.LastName);
                    myCommand.Parameters.AddWithValue("@Gender", learner.Gender);
                    myCommand.Parameters.AddWithValue("@DateofBirth", learner.DateofBirth);
                    myCommand.Parameters.AddWithValue("@IDNumber", (object)learner.IDNumber ?? DBNull.Value);
                    myCommand.Parameters.AddWithValue("@Email", learner.Email);
                    myCommand.Parameters.AddWithValue("@Cell", learner.Cell);
                    myCommand.Parameters.AddWithValue("@Country", learner.Country);
                    myCommand.Parameters.AddWithValue("@Province", learner.Province);
                    myCommand.Parameters.AddWithValue("@City", learner.City);
                    myCommand.Parameters.AddWithValue("@SchoolName", learner.SchoolName);
                    myCommand.Parameters.AddWithValue("@Grade", learner.Grade);
                    myCommand.Parameters.AddWithValue("@Stream", learner.Stream);

                    myCommand.ExecuteNonQuery();
                }
            }

            return new JsonResult("Learner added successfully");
        }
    }
}
