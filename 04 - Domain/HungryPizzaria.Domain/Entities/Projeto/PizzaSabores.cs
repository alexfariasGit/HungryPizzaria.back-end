using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Domain.Operation.Entities.Projeto
{
    public class PizzaSabores
    {
        public int IDPIZZA { get; set; }
        public string DESCRICAO { get; set; }
        public double VALORES { get; set; }
        public bool STATUS { get; set; }

        public List<ItensPedido> ItensPedido { get; set; }
        public DateTime DTINCLUSAO { get; set; }
        public DateTime DTALTERACAO { get; set; }
    }
}
