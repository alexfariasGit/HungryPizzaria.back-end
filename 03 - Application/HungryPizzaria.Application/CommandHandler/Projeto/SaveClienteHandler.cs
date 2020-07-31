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
    public class SaveClienteHandler : IRequestHandler<SaveCliente, Message<Cliente>>
    {
       private readonly IClienteRepository _repositoryCliente;

        private readonly IMapper _mapper;

        public SaveClienteHandler(IMapper mapper, IClienteRepository IClassificaoRepository)
        {
            _mapper = mapper;
            this._repositoryCliente = IClassificaoRepository;
        }

        private bool ExistsClientes(SaveCliente request)
        {

            return _repositoryCliente.entity().Any(c =>  c.IDCLIENTE == request.IDCLIENTE);
        }

        public async Task<Message<Cliente>> Handle(SaveCliente request, CancellationToken cancellationToken)
        {
            var message = new Message<Cliente>();
            try
            {

                var mClientes = _mapper.Map<Cliente>(request);

                if (mClientes.IDCLIENTE > 0)
                {


                    mClientes.DTALTERACAO = DateTime.Now;

                    _repositoryCliente.entity().Update(mClientes);
                    await _repositoryCliente.SaveChangesAsync();

                    message.CreateMessageSuccess("Cliente alterado com sucesso!", mClientes);
                }
                else
                {
                    if (!ExistsClientes(request))
                    {

                        mClientes.DTINCLUSAO = DateTime.Now;
                        _repositoryCliente.entity().Add(mClientes);

                        await _repositoryCliente.SaveChangesAsync();

                        message.CreateMessageSuccess("Cliente salvo com sucesso!", mClientes);
                    }
                    else
                    {
                        message.CreateMessageAlert("Validações", new List<string> { "Cliente já cadastrado! " });
                    }
                }
                return message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao salvar Cliente!");
                return message;
            }
            finally
            {
                message = null;
            }


        }
       
    }
}