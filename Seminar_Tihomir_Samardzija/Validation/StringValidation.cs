using Seminar_Tihomir_Samardzija.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Validation
{
    public class StringGreaterThanThanSeven : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            if (value is string)
            {
                string input = (string)value;
                if (input.StringGreaterThan(7))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Unos ima manje od 7 znakova!");
            }

            return new ValidationResult("Unos nije validan!");

        }
    }
}
