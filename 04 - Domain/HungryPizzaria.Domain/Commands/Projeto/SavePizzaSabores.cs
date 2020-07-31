using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HungryPizzaria.SDK.Models;
using HungryPizzaria.Domain.Operation.Entities.Projeto;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class SavePizzaSabores : IRequest<Message<Domain.Operation.Entities.Projeto.PizzaSabores>>
    {
        public int IDPIZZA { get; set; }
        public string DESCRICAO { get; set; }
        public double VALORES { get; set; }
        public bool STATUS { get; set; }

        public DateTime DTINCLUSAO { get; set; }
        public DateTime DTALTERACAO { get; set; }

    }
}
