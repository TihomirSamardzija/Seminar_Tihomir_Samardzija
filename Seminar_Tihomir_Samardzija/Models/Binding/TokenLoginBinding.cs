using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class TokenLoginBinding
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
