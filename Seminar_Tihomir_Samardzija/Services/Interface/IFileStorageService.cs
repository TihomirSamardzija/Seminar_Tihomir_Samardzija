using Seminar_Tihomir_Samardzija.Models.ViewModel;

namespace Seminar_Tihomir_Samardzija.Services.Interface
{
    public interface IFileStorageService
    {
        Task<bool> DeleteFile(int id);
        Task<FileStorageViewModel> AddFileToStorage(IFormFile file);
        Task<FileStorageExpendedViewModel> GetFile(long id);
    }
}
