using AutoMapper;

using HungryPizzaria.Domain.Operation.Commands.Projeto;
using HungryPizzaria.Domain.Operation.Entities.Projeto;
using HungryPizzaria.Domain.Operation.Repository.Projeto;
using HungryPizzaria.SDK.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizzaria.Application.Operation.CommandHandler.Projeto
{
    public class DeleteItensPedidoHandler : IRequestHandler<DeleteItensPedido, Message<ItensPedido>>
    {

        readonly IItensPedidoRepository _repositoryItensPedido;

        private readonly IMapper _mapper;

        public DeleteItensPedidoHandler(IMapper mapper, IItensPedidoRepository IItensPedidoRepository)
        {
            _mapper = mapper;            
            this._repositoryItensPedido = IItensPedidoRepository;
        }

        public async Task<Message<ItensPedido>> Handle(DeleteItensPedido request, CancellationToken cancellationToken)
        {
            var message = new Message<ItensPedido>();
            try
            {

                var mItensPedido = _repositoryItensPedido.entity().FirstOrDefault(c => c.IDITENSPEDIDOS == request.IDITENSPEDIDOS);

                if (mItensPedido != null)
                {
                    _repositoryItensPedido.entity().Remove(mItensPedido);

                    await _repositoryItensPedido.SaveChangesAsync();
                    message.CreateMessageSuccess("ItensPedido removido com sucesso!", mItensPedido);
                }
                else
                {
                    message.CreateMessageAlert("ItensPedido não localizada!", new List<string> { "ItensPedido não localizada pelo identificador" });
                }

                

                return  message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao remover ItensPedido!");
                return  message;
            }
            finally
            {
                message = null;
            }
        }        
    }
}
