using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HungryPizzaria.SDK.Core
{
    public class ConditionalRequiredAttribute : ValidationAttribute
    {

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var model = validationContext.ObjectInstance as EmployeeInputModel;

        //    if (model == null)
        //        throw new ArgumentException("Attribute not applied on Employee");

        //    if (model.BirthDate > DateTime.Now.Date)
        //        return new ValidationResult(GetErrorMessage(validationContext));

        //    return ValidationResult.Success;
        //}

        //private string GetErrorMessage(ValidationContext validationContext)
        //{
        //    // Message that was supplied
        //    if (!string.IsNullOrEmpty(this.ErrorMessage))
        //        return this.ErrorMessage;

        //    // Use generic message: i.e. The field {0} is invalid
        //    //return this.FormatErrorMessage(validationContext.DisplayName);

        //    // Custom message
        //    return $"{validationContext.DisplayName} can't be in future";
        //}
    }
}
