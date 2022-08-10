
using Seminar_Tihomir_Samardzija.Validation;
using Seminar_Tihomir_Samardzija.Models.Base;
using Seminar_Tihomir_Samardzija.Models.ViewModel;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class ProductUpdateBinding: ProductBase
    {
        //[ProductIdValidation]
        public int Id { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }
        [ProductCategoryIdValidation]
        public int ProductCategoryId { get; set; }
    }
}
