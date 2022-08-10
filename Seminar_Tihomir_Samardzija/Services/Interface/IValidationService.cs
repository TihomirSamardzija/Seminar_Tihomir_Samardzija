namespace Seminar_Tihomir_Samardzija.Services.Interface
{
    public interface IValidationService
    {
        Task<bool> UsersIdValid(string id);
        Task<bool> EmailExists(string email);
        Task<bool> ProductIdValid(int id);
        Task<bool> ProductCategoryIdValid(int id);
    }
}
