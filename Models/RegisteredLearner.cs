
namespace backEnd.Models
{
    public class RegisteredLearner
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }  // ⚠️ must be a valid date
        public string Email { get; set; }
        public string Cellphone { get; set; }
    }
}