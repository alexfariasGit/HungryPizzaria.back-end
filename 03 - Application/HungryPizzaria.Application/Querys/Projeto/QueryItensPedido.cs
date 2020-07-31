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
    public class QueryItensPedido : IQueryItensPedido
    {

        private readonly IMapper _mapper;        
        readonly HungryPizzaria.Domain.Operation.Repository.Projeto.IItensPedidoRepository _repositoryItensPedido;

        public QueryItensPedido(IMapper mapper, HungryPizzaria.Domain.Operation.Repository.Projeto.IItensPedidoRepository IItensPedidoRepository)
        {           
            this._mapper = mapper;
            this._repositoryItensPedido = IItensPedidoRepository;            
        }      

        public async Task<Message<HungryPizzaria.Domain.Operation.Entities.Projeto.ItensPedido>> GetByItensPedido(int IDItensPedido)
        {
            var message = new Message<HungryPizzaria.Domain.Operation.Entities.Projeto.ItensPedido>();
            try
            {
                var result = await _repositoryItensPedido.entity().Where(c => c.IDITENSPEDIDOS == IDItensPedido).FirstOrDefaultAsync();

                message.CreateMessageSuccess("Contato obtido com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Não foi possível obter Contato!");
            }

            return message;
        }       

        public async Task<Message<List<HungryPizzaria.Domain.Operation.Entities.Projeto.ItensPedido>>> GetAllItensPedido()
        {
            var message = new Message<List<HungryPizzaria.Domain.Operation.Entities.Projeto.ItensPedido>>();
            try
            {
                var result = await _repositoryItensPedido.entity().ToListAsync();

                message.CreateMessageSuccess("ItensPedido obtidos com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar ItensPedido");
            }

            return message;
        }
       
    }
}
