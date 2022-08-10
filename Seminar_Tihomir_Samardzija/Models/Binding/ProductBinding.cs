using Seminar_Tihomir_Samardzija.Models.Base;
using Seminar_Tihomir_Samardzija.Validation;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class ProductBinding : ProductBase
    {
        [ProductCategoryIdValidation]
        public int ProductCategoryId { get; set; }
        [Display(Name = "Slika proizvoda")]
        public IFormFile ProductImg { get; set; }
    }
}
