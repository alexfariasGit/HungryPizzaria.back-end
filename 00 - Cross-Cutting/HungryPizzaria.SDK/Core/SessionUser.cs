using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.SDK.Core
{
    public class SessionUser
    {
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string Licence { get; set; }
        public long LicenceId { get; set; }

        public List<string> Actions { get; set; }
    }
}
