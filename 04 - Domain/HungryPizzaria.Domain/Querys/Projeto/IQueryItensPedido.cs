using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HungryPizzaria.SDK.Models;

namespace HungryPizzaria.Domain.Operation.Querys.Projeto
{
    public interface IQueryItensPedido
    {        

        Task<SDK.Models.Message<List<Domain.Operation.Entities.Projeto.ItensPedido>>> GetAllItensPedido();

        Task<SDK.Models.Message<Domain.Operation.Entities.Projeto.ItensPedido>> GetByItensPedido(int IDItensPedido);        
    }
}
