namespace Seminar_Tihomir_Samardzija.Models.Dbo.Base
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
