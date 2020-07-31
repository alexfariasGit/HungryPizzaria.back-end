using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HungryPizzaria.SDK.Models;
using HungryPizzaria.Domain.Operation.Entities.Projeto;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class SaveItensPedido : IRequest<Message<Domain.Operation.Entities.Projeto.ItensPedido>>
    {
        public int IDITENSPEDIDOS { get; set; }
        public int IDPEDIDOS { get; set; }
        public bool INTEIRA { get; set; }
        public int IDPIZZA { get; set; }
        public double TOTAL { get; set; }

        public Pedidos Pedidos { get; set; }
        public List<PizzaSabores> PizzaSabores { get; set; }

    }
}
