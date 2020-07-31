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
    public class SaveItensPedidoHandler : IRequestHandler<SaveItensPedido, Message<ItensPedido>>
    {
       private readonly IItensPedidoRepository _repositoryItensPedido;

        private readonly IMapper _mapper;

        public SaveItensPedidoHandler(IMapper mapper, IItensPedidoRepository IItensPedidoRepository)
        {
            _mapper = mapper;
            this._repositoryItensPedido = IItensPedidoRepository;
        }

        private bool ExistsItensPedidos(SaveItensPedido request)
        {

            return _repositoryItensPedido.entity().Any(c =>  c.IDITENSPEDIDOS == request.IDITENSPEDIDOS);
        }

        public async Task<Message<ItensPedido>> Handle(SaveItensPedido request, CancellationToken cancellationToken)
        {
            var message = new Message<ItensPedido>();
            try
            {

                var mItensPedidos = _mapper.Map<ItensPedido>(request);

                if (mItensPedidos.IDITENSPEDIDOS > 0)
                {
                    
                    var mItensPedidos2 = _repositoryItensPedido.entity().FirstOrDefault(c => c.IDITENSPEDIDOS == mItensPedidos.IDITENSPEDIDOS);                                      

                   
                    mItensPedidos2.DTINCLUSAO = mItensPedidos.DTINCLUSAO;
                 

                    _repositoryItensPedido.entity().Update(mItensPedidos2);
                    await _repositoryItensPedido.SaveChangesAsync();

                    message.CreateMessageSuccess("Item alterado com sucesso!", mItensPedidos2);
                }
                else
                {
                    if (!ExistsItensPedidos(request))
                    {

                        mItensPedidos.DTINCLUSAO = DateTime.Now;
                        _repositoryItensPedido.entity().Add(mItensPedidos);

                        await _repositoryItensPedido.SaveChangesAsync();

                        message.CreateMessageSuccess("Item salvo com sucesso!", mItensPedidos);
                    }
                    else
                    {
                        message.CreateMessageAlert("Validações", new List<string> { "Item já cadastrado! " });
                    }
                }
                return message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao salvar Item!");
                return message;
            }
            finally
            {
                message = null;
            }


        }
       
    }
}