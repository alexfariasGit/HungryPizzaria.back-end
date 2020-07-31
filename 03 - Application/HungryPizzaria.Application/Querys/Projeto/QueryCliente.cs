using AutoMapper;

using HungryPizzaria.Domain.Operation.Entities.Projeto;
using HungryPizzaria.Domain.Operation.Querys.Projeto;
using HungryPizzaria.Domain.Operation.Repository.Projeto;
using HungryPizzaria.SDK.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaria.Application.Querys.Projeto
{
    public class QueryCliente : IQueryCliente
    {

        private readonly IMapper _mapper;        
        readonly IClienteRepository _repositoryCliente;

        public QueryCliente(IMapper mapper, IClienteRepository IClienteRepository)
        {
            this._mapper = mapper;
            this._repositoryCliente = IClienteRepository;            
        }       

        public async Task<Message<Cliente>> GetByIDCliente(int IDCliente)
        {
            var message = new Message<Cliente>();
            try
            {
                var result = await _repositoryCliente.entity().Include("Pedidos").Where(c => c.IDCLIENTE == IDCliente).FirstOrDefaultAsync();

                message.CreateMessageSuccess("Cliente obtido com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Não foi possível obter Cliente!");
            }

            return message;
        }

        public async Task<Message<Cliente>> GetByTelefoneCliente(string telefone)
        {
            var message = new Message<Cliente>();
            try
            {
                var result = await _repositoryCliente.entity().Include("Pedidos").Where(c => c.TELEFONE == telefone).FirstOrDefaultAsync();

                message.CreateMessageSuccess("Cliente obtido com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Não foi possível obter Cliente!");
            }

            return message;
        }
        public async Task<Message<List<Cliente>>> GetAllCliente()
        {
            var message = new Message<List<Cliente>>();
            try
            {
                var result = await _repositoryCliente.entity().ToListAsync();

                message.CreateMessageSuccess("Clientes obtidos com sucesso", result);
            }
            catch (Exception ex)
            {
                message.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar Cliente");
            }

            return message;
        }

      
    }
}
