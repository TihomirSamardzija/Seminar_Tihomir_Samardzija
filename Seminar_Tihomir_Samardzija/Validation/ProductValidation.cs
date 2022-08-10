using Seminar_Tihomir_Samardzija.Extensions;
using Seminar_Tihomir_Samardzija.Models.Binding.Interface;
using Seminar_Tihomir_Samardzija.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Validation
{
    public class ProductValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


            if (value is IProduct)
            {
                IProduct product = (IProduct)value;

                if (validationService.ProductCategoryIdValid(product.ProductCategoryId).Result && product.Value.GreaterThan(0))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Product nije validan!");

            }

            return new ValidationResult("Product je validan!");

        }
    }
}
