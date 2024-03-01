using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomActionFilters
{
    public class DateEndValidationAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public DateEndValidationAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endDate = (DateTime)value;

            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (startDateProperty == null)
            {
                return new ValidationResult($"La propriété {_startDatePropertyName} n'a pas été trouvée.");
            }

            var startDate = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance, null);

            if (endDate < startDate)
            {
                return new ValidationResult("La date de fin doit être égale ou postérieure à la date de début.");
            }

            return ValidationResult.Success;
        }
    }
}
