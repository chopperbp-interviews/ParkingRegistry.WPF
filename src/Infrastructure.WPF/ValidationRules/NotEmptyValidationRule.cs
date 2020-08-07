using System.Globalization;
using System.Windows.Controls;

namespace ParkingRegistry.Infrastructure.WPF.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = string.IsNullOrWhiteSpace((value ?? "").ToString()) ? new ValidationResult(false, "Mező kitöltése kötelező") : ValidationResult.ValidResult; ;
            return result;
        }
    }
}
