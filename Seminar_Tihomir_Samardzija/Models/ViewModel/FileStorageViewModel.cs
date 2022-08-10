using Seminar_Tihomir_Samardzija.Models.Base;
using System.Net.Mime;

namespace Seminar_Tihomir_Samardzija.Models.ViewModel
{
    public class FileStorageViewModel : FileStorageBase
    {
        public int Id { get; set; }
    }


    public class FileStorageExpendedViewModel : FileStorageBase
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public FileStream FileStream { get; set; }
        public ContentDisposition ContentDisposition { get; set; }
    }
}
