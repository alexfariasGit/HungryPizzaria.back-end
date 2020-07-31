using System;
using System.Collections.Generic;

namespace HungryPizzaria.Domain.Operation.Entities.Projeto
{
    public class Cliente
    {
        public Cliente() { }
        public int IDCLIENTE { get; set; }
        public string CPF { get; set; }
        public string NOME { get; set; }
        public string TELEFONE { get; set; }
        public DateTime DTNASCIMENTO { get; set; }
        public string LOGRADOURO { get; set; }
        public int NUMERO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }

        public List<Pedidos> Pedidos { get; set; }
        public DateTime DTINCLUSAO { get; set; }
        public DateTime DTALTERACAO { get; set; }
    }
}
