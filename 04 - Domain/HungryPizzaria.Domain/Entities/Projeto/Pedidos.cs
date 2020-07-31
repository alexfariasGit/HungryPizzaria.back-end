using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Domain.Operation.Entities.Projeto
{
    public class Pedidos
    {
        public int IDPEDIDOS { get; set; }
        public int IDCLIENTE { get; set; }
        public double TOTAL { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItensPedido> ItensPedidos { get; set; }
        public DateTime DTINCLUSAO { get; set; }
    }
}
