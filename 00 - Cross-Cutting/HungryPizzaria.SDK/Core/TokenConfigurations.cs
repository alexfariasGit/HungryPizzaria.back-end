using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.SDK.Core
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public string SecretKey { get; set; }


    }
   
}
