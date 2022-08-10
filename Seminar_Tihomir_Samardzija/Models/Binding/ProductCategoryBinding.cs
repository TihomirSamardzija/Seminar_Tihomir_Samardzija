using Seminar_Tihomir_Samardzija.Models.Base;
using Seminar_Tihomir_Samardzija.Validation;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class ProductCategoryBinding : ProductCategoryBase
    {
    }

    public class ProductCategoryUpdateBinding : ProductCategoryBinding
    {
        [ProductCategoryIdValidation]
        public int Id { get; set; }
    }
}
