using Seminar_Tihomir_Samardzija.Validation;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class UserBinding: UserBaseBinding
    {
        public AdressBinding UserAdress { get; set; }
    }

    public class UserBaseBinding
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DOB { get; set; }
        [UserEmailValidation]
        public string Email { get; set; }
        [StringGreaterThanThanSeven]
        public string Password { get; set; }
    }

    public class UserAdminBinding : UserBaseBinding
    {
        public string RoleId { get; set; }
    }

    public class UserAdminUpdateBinding : UserAdminBinding
    {
        public string Id { get; set; }
    }
}
