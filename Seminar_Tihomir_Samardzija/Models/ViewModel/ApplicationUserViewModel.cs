using Seminar_Tihomir_Samardzija.Models.Base;

namespace Seminar_Tihomir_Samardzija.Models.ViewModel
{

    public class ApplicationUserViewModel : ApplicationUserBase
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public List<AdressViewModel> Adress { get; set; }
    }
}
