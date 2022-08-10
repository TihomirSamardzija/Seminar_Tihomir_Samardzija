namespace Seminar_Tihomir_Samardzija.Models.Dto
{
    public class AppConfig
    {
        public Identity Identity { get; set; }
        public string AppUrl { get; set; }
    }

    public class Identity
    {
        public string Key { get; set; }
    }
}
