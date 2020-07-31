using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HungryPizzaria.SDK.Models;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class DeletePedidos : IRequest<Message<Domain.Operation.Entities.Projeto.Pedidos>>
    {
        [Required(ErrorMessage = "ID é um campo obrigatório")]
        public long IDPEDIDOS { get; set; }   
    }
}
