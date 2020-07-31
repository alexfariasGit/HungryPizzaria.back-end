using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.SDK.Utils
{
    public class Base64
    {

        public static string ConverterJsonToBase64(string json)
        {
            var encodedBytes = System.Text.Encoding.Unicode.GetBytes(json);
            var encodedTxt = Convert.ToBase64String(encodedBytes);
            return encodedTxt;
        }

        public static string ConverterBase64toJson(string base64)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64);
            var decodedTxt =  System.Text.Encoding.Unicode.GetString(base64EncodedBytes);
            return decodedTxt;
        }



    }
}
