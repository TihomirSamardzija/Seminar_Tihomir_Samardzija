using Seminar_Tihomir_Samardzija.Models.Dbo.Base;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Models.Dbo
{
    public class Adress : AdressBase, IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public DateTime Created { get; set; }
    }
}
