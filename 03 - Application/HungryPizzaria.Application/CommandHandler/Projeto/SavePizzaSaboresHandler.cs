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
    public class SavePizzaSaboresHandler : IRequestHandler<SavePizzaSabores, Message<PizzaSabores>>
    {
       private readonly IPizzaSaboresRepository _repositoryPizzaSabores;

        private readonly IMapper _mapper;

        public SavePizzaSaboresHandler(IMapper mapper, IPizzaSaboresRepository IClassificaoRepository)
        {
            _mapper = mapper;
            this._repositoryPizzaSabores = IClassificaoRepository;
        }

        private bool ExistsPizzaSaboress(SavePizzaSabores request)
        {

            return _repositoryPizzaSabores.entity().Any(c =>  c.IDPIZZA == request.IDPIZZA);
        }

        public async Task<Message<PizzaSabores>> Handle(SavePizzaSabores request, CancellationToken cancellationToken)
        {
            var message = new Message<PizzaSabores>();
            try
            {

                var mPizzaSaboress = _mapper.Map<PizzaSabores>(request);

                if (mPizzaSaboress.IDPIZZA > 0)
                {

                    mPizzaSaboress.DTALTERACAO = DateTime.Now;

                    _repositoryPizzaSabores.entity().Update(mPizzaSaboress);
                    await _repositoryPizzaSabores.SaveChangesAsync();

                    message.CreateMessageSuccess("Pizza Sabores alterado com sucesso!", mPizzaSaboress);
                }
                else
                {
                    if (!ExistsPizzaSaboress(request))
                    {

                        mPizzaSaboress.DTINCLUSAO = DateTime.Now;
                        _repositoryPizzaSabores.entity().Add(mPizzaSaboress);

                        await _repositoryPizzaSabores.SaveChangesAsync();

                        message.CreateMessageSuccess("Pizza Sabores salvo com sucesso!", mPizzaSaboress);
                    }
                    else
                    {
                        message.CreateMessageAlert("Validações", new List<string> { "Pizza Sabores já cadastrado! " });
                    }
                }
                return message;

            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Erro ao salvar Pizza Sabores!");
                return message;
            }
            finally
            {
                message = null;
            }


        }
       
    }
}