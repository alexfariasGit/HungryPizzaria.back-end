using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HungryPizzaria.SDK.Models;
using HungryPizzaria.Domain.Operation.Entities.Projeto;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class SavePedidos : IRequest<Message<Domain.Operation.Entities.Projeto.Pedidos>>
    {
        public int IDPEDIDOS { get; set; }
        public int IDCLIENTE { get; set; }
        public double TOTAL { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItensPedido> ItensPedidos { get; set; }

    }
}
