using Seminar_Tihomir_Samardzija.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Models.Dbo
{
    public class Adress : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Created { get; set; }
    }
}
