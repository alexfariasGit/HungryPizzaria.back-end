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
    public class DeletePedidosHandler : IRequestHandler<DeletePedidos, Message<Pedidos>>
    {
        readonly IPedidosRepository _repositoryPedidos;

        private readonly IMapper _mapper;

        public DeletePedidosHandler(IMapper mapper,IPedidosRepository IPedidosRepository)
        {
            _mapper = mapper;           
            this._repositoryPedidos = IPedidosRepository;
        }

        public async Task<Message<Pedidos>> Handle(DeletePedidos request, CancellationToken cancellationToken)
        {
            var message = new Message<Pedidos>();
            try
            {

                var mPedidos = _repositoryPedidos.entity().Include("ItensPedido").FirstOrDefault(c => c.IDPEDIDOS == request.IDPEDIDOS);

                if (mPedidos != null)
                {
                    _repositoryPedidos.entity().Remove(mPedidos);

                    await _repositoryPedidos.SaveChangesAsync();
                    message.CreateMessageSuccess("Pedido removida com sucesso!", mPedidos);
                }
                else
                {
                    message.CreateMessageAlert("Pedido não localizada!", new List<string> { "Pedido não localizada pelo identificador" });
                }

                

                return  message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao remover Pedido!");
                return  message;
            }
            finally
            {
                message = null;
            }
        }        
    }
}
