using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HungryPizzaria.SDK.AttributeValidation
{
    public class IsValidTypeJuridica : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strValue = value as string;

            if (!string.IsNullOrEmpty(strValue))
            {
                return new string[]
                {
                "LIC", "CLI", "CON", "ADM"
                }.Contains(strValue.ToUpper());
            }
            return true;
        }
    }
}
