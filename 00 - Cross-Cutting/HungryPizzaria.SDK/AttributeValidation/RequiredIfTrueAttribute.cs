using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HungryPizzaria.SDK.AttributeValidation
{

    public class RequiredIfAttribute : ValidationAttribute
    {
        private String PropertyName { get; set; }
        private String ErrorMessage { get; set; }
        private Object ValueCompare { get; set; }

        public RequiredIfAttribute(String propertyName, Object valueCompare, String errormessage)
        {
            this.PropertyName = propertyName;
            this.ValueCompare = valueCompare;
            this.ErrorMessage = errormessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object propertyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (propertyvalue.ToString() == ValueCompare.ToString() && value == null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

}
