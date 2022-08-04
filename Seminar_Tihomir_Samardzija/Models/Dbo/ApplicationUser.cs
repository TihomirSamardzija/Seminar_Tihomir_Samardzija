using Microsoft.AspNetCore.Identity;

namespace Seminar_Tihomir_Samardzija.Models.Dbo
{
    public class ApplicationUser:IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Adress> Adress { get; set; }
    }
}
