using Seminar_Tihomir_Samardzija.Models.Dbo;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class ApplicationUserUpdateBinding:ApplicationUser
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
