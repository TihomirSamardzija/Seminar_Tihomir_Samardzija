using Seminar_Tihomir_Samardzija.Models.Base;

namespace Seminar_Tihomir_Samardzija.Models.ViewModel
{
    public class ProductViewModel : ProductBase
    {
        public int Id { get; set; }
        public ProductCategoryViewModel? ProductCategory { get; set; }
    }
}
