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
    public class QueryPedidos : IQueryPedidos
    {

        private readonly IMapper _mapper;        
        readonly HungryPizzaria.Domain.Operation.Repository.Projeto.IPedidosRepository _repositoryPedidos;

        public QueryPedidos(IMapper mapper, HungryPizzaria.Domain.Operation.Repository.Projeto.IPedidosRepository IPedidosRepository)
        {           
            this._mapper = mapper;
            this._repositoryPedidos = IPedidosRepository;            
        }      

        public async Task<Message<HungryPizzaria.Domain.Operation.Entities.Projeto.Pedidos>> GetByIDPedidos(int IDPedidos)
        {
            var message = new Message<HungryPizzaria.Domain.Operation.Entities.Projeto.Pedidos>();
            try
            {
                var result = await _repositoryPedidos.entity().Include("TelEmails").Where(c => c.IDPEDIDOS == IDPedidos).FirstOrDefaultAsync();

                message.CreateMessageSuccess("Contato obtido com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Não foi possível obter Contato!");
            }

            return message;
        }       

        public async Task<Message<List<HungryPizzaria.Domain.Operation.Entities.Projeto.Pedidos>>> GetAllPedidos()
        {
            var message = new Message<List<HungryPizzaria.Domain.Operation.Entities.Projeto.Pedidos>>();
            try
            {
                var result = await _repositoryPedidos.entity().ToListAsync();

                message.CreateMessageSuccess("Pedidos obtidos com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar Pedidos");
            }

            return message;
        }       
    }
}
