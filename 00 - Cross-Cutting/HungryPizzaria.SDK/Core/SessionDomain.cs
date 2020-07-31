using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;

namespace HungryPizzaria.SDK.Core
{
    public class SessionDomain
    {
        public JwtSecurityToken token { get; set; }       

        public SDK.Core.SessionUser _sessionUser { get; set; }

        public void PopulateFields()
        {
            var claimUniqueName = token.Claims.Where(c => c.Type == "unique_name").FirstOrDefault().Value;
            var claimTokenIdentification = token.Claims.Where(c => c.Type == "TokenIdentification").FirstOrDefault().Value;
            _sessionUser = Newtonsoft.Json.JsonConvert.DeserializeObject<SDK.Core.SessionUser>(SDK.Core.Crypto.Decrypt(claimTokenIdentification, claimUniqueName));            
        }

    }
}
