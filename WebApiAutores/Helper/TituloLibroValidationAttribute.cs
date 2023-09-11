using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Helper
{
    public class TituloLibroValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                if (char.IsUpper(value.ToString()[0]))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("El titulo del libro debe comenzar en mayúscula.");
                }

            }
            return new ValidationResult("El titulo del libro debe comenzar en mayúscula.");

        }
    }
}
