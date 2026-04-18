using System.ComponentModel.DataAnnotations;

namespace OrderService.Validation;

/// <summary>
/// Validates that the value is a positive decimal number greater than zero.
/// </summary>
public class PositiveDecimal : ValidationAttribute
{
    /// <summary>
    /// Validates whether the provided value is a positive decimal.
    /// </summary>
    /// <param name="value">
    /// The value to validate.
    /// </param>
    /// <param name="validationContext">
    /// Context information about the validation operation.
    /// </param>
    /// <returns>
    /// Success if valid, otherwise a ValidationResult containing the error.
    /// </returns>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is decimal decimalValue)
        {
            if (decimalValue > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Value must be greater than zero.");
        }
        return new ValidationResult("Value must be a decimal.");
    }
}
