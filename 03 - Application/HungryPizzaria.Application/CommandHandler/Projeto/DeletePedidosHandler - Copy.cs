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
    public class DeletePizzaSaboresHandler : IRequestHandler<DeletePizzaSabores, Message<PizzaSabores>>
    {
        readonly IPizzaSaboresRepository _repositoryPizzaSabores;

        private readonly IMapper _mapper;

        public DeletePizzaSaboresHandler(IMapper mapper,IPizzaSaboresRepository IPizzaSaboresRepository)
        {
            _mapper = mapper;           
            this._repositoryPizzaSabores = IPizzaSaboresRepository;
        }

        public async Task<Message<PizzaSabores>> Handle(DeletePizzaSabores request, CancellationToken cancellationToken)
        {
            var message = new Message<PizzaSabores>();
            try
            {

                var mPizzaSabores = _repositoryPizzaSabores.entity().FirstOrDefault(c => c.IDPIZZA == request.IDPIZZA);

                if (mPizzaSabores != null)
                {
                    _repositoryPizzaSabores.entity().Remove(mPizzaSabores);

                    await _repositoryPizzaSabores.SaveChangesAsync();
                    message.CreateMessageSuccess("Pizza Sabores removida com sucesso!", mPizzaSabores);
                }
                else
                {
                    message.CreateMessageAlert("Pizza Sabores não localizada!", new List<string> { "Pizza Sabores não localizada pelo identificador" });
                }

                

                return  message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao remover Pizza Sabores!");
                return  message;
            }
            finally
            {
                message = null;
            }
        }        
    }
}
