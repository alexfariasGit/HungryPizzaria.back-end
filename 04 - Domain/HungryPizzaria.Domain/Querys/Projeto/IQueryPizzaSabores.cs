using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HungryPizzaria.SDK.Models;

namespace HungryPizzaria.Domain.Operation.Querys.Projeto
{
    public interface IQueryPizzaSabores
    {

        Task<SDK.Models.Message<List<Domain.Operation.Entities.Projeto.PizzaSabores>>> GetAllPizzaSabores();

        Task<SDK.Models.Message<Domain.Operation.Entities.Projeto.PizzaSabores>> GetByIDPizzaSabores(int iDPizzaSabores);

    }
}
