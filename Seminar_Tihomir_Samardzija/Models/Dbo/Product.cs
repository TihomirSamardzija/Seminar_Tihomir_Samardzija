using Seminar_Tihomir_Samardzija.Models.Base;
using Seminar_Tihomir_Samardzija.Models.Dbo.Base;

namespace Seminar_Tihomir_Samardzija.Models.Dbo
{
    public class Product : ProductBase, IEntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

    }
}
