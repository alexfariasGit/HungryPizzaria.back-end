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
    public class SavePedidosHandler : IRequestHandler<SavePedidos, Message<Pedidos>>
    {
       private readonly IPedidosRepository _repositoryPedidos;

        private readonly IMapper _mapper;

        public SavePedidosHandler(IMapper mapper, IPedidosRepository IClassificaoRepository)
        {
            _mapper = mapper;
            this._repositoryPedidos = IClassificaoRepository;
        }

        private bool ExistsPedidoss(SavePedidos request)
        {

            return _repositoryPedidos.entity().Any(c =>  c.IDPEDIDOS == request.IDPEDIDOS);
        }

        public async Task<Message<Pedidos>> Handle(SavePedidos request, CancellationToken cancellationToken)
        {
            var message = new Message<Pedidos>();
            try
            {

                var mPedidoss = _mapper.Map<Pedidos>(request);

                if (mPedidoss.IDPEDIDOS > 0)
                {
                    
                    var mPedidoss2 = _repositoryPedidos.entity().FirstOrDefault(c => c.IDPEDIDOS == mPedidoss.IDPEDIDOS);                                      

                   
                    mPedidoss2.DTINCLUSAO = mPedidoss.DTINCLUSAO;                 

                    _repositoryPedidos.entity().Update(mPedidoss2);
                    await _repositoryPedidos.SaveChangesAsync();

                    message.CreateMessageSuccess("Pedido alterado com sucesso!", mPedidoss2);
                }
                else
                {
                    if (!ExistsPedidoss(request))
                    {

                        mPedidoss.DTINCLUSAO = DateTime.Now;
                        _repositoryPedidos.entity().Add(mPedidoss);

                        await _repositoryPedidos.SaveChangesAsync();

                        message.CreateMessageSuccess("Pedido salvo com sucesso!", mPedidoss);
                    }
                    else
                    {
                        message.CreateMessageAlert("Validações", new List<string> { "Pedido já cadastrado! " });
                    }
                }
                return message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao salvar Pedido!");
                return message;
            }
            finally
            {
                message = null;
            }


        }
       
    }
}