using System;
using System.ComponentModel.DataAnnotations;

namespace AgencyAddressBook.Helpers
{
    public class ValidateDateOfBirth : ValidationAttribute
    {
        protected override ValidationResult
        IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dob = Convert.ToDateTime(value);
            var age = (int)((DateTime.Now - _dob).TotalDays / 365.242199);
            if (age > 18 && age < 85)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ($"Age {age} is not eligible.");
            }
        }
    }
}