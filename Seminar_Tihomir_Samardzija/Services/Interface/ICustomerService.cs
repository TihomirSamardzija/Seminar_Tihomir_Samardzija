using Seminar_Tihomir_Samardzija.Models.ViewModel;

namespace Seminar_Tihomir_Samardzija.Services.Interface
{
    public interface ICustomerService
    {
        Task<AdressViewModel> GetAdress(string userId);
    }
}
