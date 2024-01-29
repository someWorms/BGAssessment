using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace AgeCalculator.Common
{
    /// <summary>
    /// Validates if passed datetime is in the future.
    /// </summary>
    public class DateTimeFutureAttribute : ValidationAttribute
    {
        DateTime now;

        public DateTimeFutureAttribute() 
        {
            now = DateTime.Now; 
        }

        public override bool IsValid(object? value)
        {
            return value != null && (DateTime)value < now;
        }

    }
}
