using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Helper
{
    public class PrecioLibroValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => (decimal)value > 0.0m;
    }
}
