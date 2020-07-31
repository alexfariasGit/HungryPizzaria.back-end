using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Domain.Operation.Entities.Projeto
{
    public class ItensPedido
    {
        public int IDITENSPEDIDOS { get; set; }
        public int IDPEDIDOS { get; set; }
        public bool INTEIRA { get; set; }
        public int IDPIZZA { get; set; }
        public double TOTAL { get; set; }

        public Pedidos Pedidos { get; set; }
        public PizzaSabores PizzaSabores { get; set; }
        public DateTime DTINCLUSAO { get; set; }
    }
}
