using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HungryPizzaria.SDK.Models;
using HungryPizzaria.Domain.Operation.Entities.Projeto;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class SaveCliente : IRequest<Message<Domain.Operation.Entities.Projeto.Cliente>>
    {       

        public int IDCLIENTE { get; set; }
        public string CPF { get; set; }
        public string NOME { get; set; }
        public string TELEFONE { get; set; }
        public string DTNASCIMENTO { get; set; }
        public string LOGRADOURO { get; set; }
        public int NUMERO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public DateTime DTINCLUSAO { get; set; }
        public DateTime DTALTERACAO { get; set; }

        public List<Pedidos> Pedidos { get; set; }      

    }
}
