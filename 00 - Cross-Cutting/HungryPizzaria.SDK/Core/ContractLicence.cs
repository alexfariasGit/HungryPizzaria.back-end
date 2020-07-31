using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.SDK.Core
{
    public class ContractLicence
    {
        public long idLicenciada { get; set; }
        public string nrCnpj { get; set; }
        public string urlApi { get; set; }
        public DateTime dtContrato { get; set; }
        public DateTime dtTerminoContrato { get; set; }
        public long IDPlano { get; set; }
        public long NRLicencas { get; set; }
    }
}
