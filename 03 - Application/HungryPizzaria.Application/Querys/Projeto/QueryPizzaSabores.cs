using AutoMapper;

using HungryPizzaria.Domain.Operation.Querys.Projeto;
using HungryPizzaria.SDK.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaria.Application.Querys.Projeto
{
    public class QueryPizzaSabores : IQueryPizzaSabores
    {

        private readonly IMapper _mapper;        
        readonly HungryPizzaria.Domain.Operation.Repository.Projeto.IPizzaSaboresRepository _repositoryPizzaSabores;

        public QueryPizzaSabores(IMapper mapper, HungryPizzaria.Domain.Operation.Repository.Projeto.IPizzaSaboresRepository IPizzaSaboresRepository)
        {           
            this._mapper = mapper;
            this._repositoryPizzaSabores = IPizzaSaboresRepository;            
        }      

        public async Task<Message<HungryPizzaria.Domain.Operation.Entities.Projeto.PizzaSabores>> GetByIDPizzaSabores(int IDPizzaSabores)
        {
            var message = new Message<HungryPizzaria.Domain.Operation.Entities.Projeto.PizzaSabores>();
            try
            {
                var result = await _repositoryPizzaSabores.entity().Where(c => c.IDPIZZA == IDPizzaSabores).FirstOrDefaultAsync();

                message.CreateMessageSuccess("Contato obtido com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Não foi possível obter Contato!");
            }

            return message;
        }       

        public async Task<Message<List<HungryPizzaria.Domain.Operation.Entities.Projeto.PizzaSabores>>> GetAllPizzaSabores()
        {
            var message = new Message<List<HungryPizzaria.Domain.Operation.Entities.Projeto.PizzaSabores>>();
            try
            {
                var result = await _repositoryPizzaSabores.entity().ToListAsync();

                message.CreateMessageSuccess("PizzaSabores obtidos com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar PizzaSabores");
            }

            return message;
        }       
    }
}
