using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HungryPizzaria.SDK.Models;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class DeleteItensPedido : IRequest<Message<Domain.Operation.Entities.Projeto.ItensPedido>>
    {
        [Required(ErrorMessage = "ID é um campo obrigatório")]
        public long IDITENSPEDIDOS { get; set; }   
    }
}
