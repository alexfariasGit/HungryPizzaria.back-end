using AutoMapper;

using HungryPizzaria.Domain.Operation.Commands.Projeto;
using HungryPizzaria.Domain.Operation.Entities.Projeto;
using HungryPizzaria.Domain.Operation.Repository.Projeto;
using HungryPizzaria.SDK.Models;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizzaria.Application.Operation.CommandHandler.Projeto
{
    public class DeleteClienteHandler : IRequestHandler<DeleteCliente, Message<Cliente>>
    {

        readonly IClienteRepository _repositoryCliente;

        private readonly IMapper _mapper;

        public DeleteClienteHandler(IMapper mapper, IClienteRepository IClienteRepository)
        {
            _mapper = mapper;            
            this._repositoryCliente = IClienteRepository;
        }

        public async Task<Message<Cliente>> Handle(DeleteCliente request, CancellationToken cancellationToken)
        {
            var message = new Message<Cliente>();
            try
            {

                var mCliente = _repositoryCliente.entity().FirstOrDefault(c => c.IDCLIENTE == request.IDCLIENTE);

                if (mCliente != null)
                {
                    _repositoryCliente.entity().Remove(mCliente);

                    await _repositoryCliente.SaveChangesAsync();
                    message.CreateMessageSuccess("Cliente removido com sucesso!", mCliente);
                }
                else
                {
                    message.CreateMessageAlert("Cliente não localizada!", new List<string> { "Cliente não localizada pelo identificador" });
                }

                

                return  message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao remover Cliente!");
                return  message;
            }
            finally
            {
                message = null;
            }
        }

     
    }
}
