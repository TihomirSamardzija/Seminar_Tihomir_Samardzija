using Seminar_Tihomir_Samardzija.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace Seminar_Tihomir_Samardzija.Validation
{
    public class UserEmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


            if (value is string)
            {
                string email = (string)value;
                if (!validationService.EmailExists(email).Result)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Email vec postoji!");

            }

            return new ValidationResult("Email nije validan!");

        }
    }

    public class UserIdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var validationService = (IValidationService)validationContext.GetService(typeof(IValidationService));


            if (value is string)
            {
                string id = (string)value;
                if (validationService.UsersIdValid(id).Result)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("UserId ne postoji!");

            }

            return new ValidationResult("UserID nije validan!");

        }
    }
}
