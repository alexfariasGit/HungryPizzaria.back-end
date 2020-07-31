using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace HungryPizzaria.SDK.Utils
{
    public static class Validation
    {
        public static List<string> Format(ModelStateDictionary modelState)
        {
            var lsVal = new List<string>();
            modelState.Values.ToList().ForEach((item) =>
            {
                item.Errors.ToList().ForEach((item2) =>
                {
                    lsVal.Add(item2.ErrorMessage);
                });
            });

            return lsVal;

        }
    }
}