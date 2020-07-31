using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using HungryPizzaria.Domain.Operation.Entities.Projeto;
using HungryPizzaria.SDK.Models;

namespace HungryPizzaria.Domain.Operation.Querys.Projeto
{
    public interface IQueryCliente
    {

        Task<SDK.Models.Message<List<Cliente>>> GetAllCliente();

        Task<Message<Cliente>> GetByIDCliente(int IDCliente);
        Task<Message<Cliente>> GetByTelefoneCliente(string telefone);

    }
}
