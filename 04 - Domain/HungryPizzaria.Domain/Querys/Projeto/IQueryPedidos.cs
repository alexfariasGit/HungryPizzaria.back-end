using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HungryPizzaria.SDK.Models;

namespace HungryPizzaria.Domain.Operation.Querys.Projeto
{
    public interface IQueryPedidos
    {

        Task<SDK.Models.Message<List<Domain.Operation.Entities.Projeto.Pedidos>>> GetAllPedidos();

        Task<SDK.Models.Message<Domain.Operation.Entities.Projeto.Pedidos>> GetByIDPedidos(int iDPedidos);

    }
}
