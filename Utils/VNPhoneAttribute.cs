using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Import_Export_Company.Utils
{
    public partial class VNPhoneAttribute : ValidationAttribute
    {
        [GeneratedRegex(@"^(0)(3|5|7|8|9)[0-9]{8}$")]
        private static partial Regex VNPhoneRegex();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            string phone = value.ToString()!;

            if (VNPhoneRegex().IsMatch(phone))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Số điện thoại không đúng định dạng Việt Nam (10 số, bắt đầu bằng 03,05,07,08,09).");
        }
    }
}
