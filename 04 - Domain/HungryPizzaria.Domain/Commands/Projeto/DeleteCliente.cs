using HungryPizzaria.SDK.Models;

using MediatR;

using System.ComponentModel.DataAnnotations;

namespace HungryPizzaria.Domain.Operation.Commands.Projeto
{
    public class DeleteCliente : IRequest<Message<Domain.Operation.Entities.Projeto.Cliente>>
    {
        [Required(ErrorMessage = "ID é um campo obrigatório")]
        public long IDCLIENTE { get; set; }   
    }
}
