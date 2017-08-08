using System;
using System.ComponentModel.DataAnnotations;

namespace AgencyAddressBook.Helpers
{
    public class ValidCreatedDate : ValidationAttribute
    {
        protected override ValidationResult
        IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateJoin = Convert.ToDateTime(value);
            if (_dateJoin < DateTime.UtcNow)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Created date can not be greater than current date.");
            }
        }
    }
}