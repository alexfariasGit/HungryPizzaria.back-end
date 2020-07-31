using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HungryPizzaria.SDK.Models;
using HungryPizzaria.SDK.Utils;

using MediatR;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizzaria.Api.Controllers
{
    [Route("api/[controller]")]
    public class PizzaSaboresController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Domain.Operation.Querys.Projeto.IQueryPizzaSabores _queryPizzaSabores;

        /// <summary>
        /// Construtor
        /// </summary>
        public PizzaSaboresController(IMediator mediator, Domain.Operation.Querys.Projeto.IQueryPizzaSabores IQueryPizzaSabores)
        {
            _mediator = mediator;
            _queryPizzaSabores = IQueryPizzaSabores;
        }

        /// <summary>
        /// Consulta de pessoas juridicas
        /// </summary>
        /// <param name="GetAllPizzaSabores"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllPizzaSabores))]
        public async Task<Message<List<Domain.Operation.Entities.Projeto.PizzaSabores>>> GetAllPizzaSabores()
        {
            try
            {


                var response = await _queryPizzaSabores.GetAllPizzaSabores();
                return response;



            }
            catch (Exception ex)
            {
                var msg = new Message<List<Domain.Operation.Entities.Projeto.PizzaSabores>>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar PizzaSabores");
                return msg;
            }

        }

        /// <summary>
        /// Metodo responsável por obter o projeto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetByIDPizzaSabores))]
        public async Task<Message<Domain.Operation.Entities.Projeto.PizzaSabores>> GetByIDPizzaSabores(int id)
        {

            try
            {
                var response = await _queryPizzaSabores.GetByIDPizzaSabores(id);
                return response;
            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.PizzaSabores>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao obter o Plano");
                return msg;
            }


        }

        /// <summary>
        /// Salvar dados empresa
        /// </summary>
        /// <param name="saveProjeto"></param>
        /// <returns></returns>
        [HttpPut(nameof(Save))]
        [DisableCors]
        public async Task<Message<Domain.Operation.Entities.Projeto.PizzaSabores>> Save([FromBody] Domain.Operation.Commands.Projeto.SavePizzaSabores savePizzaSabores)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(savePizzaSabores);
                    return response;
                }
                else
                {
                    var lsVal = new List<string>();
                    lsVal = Validation.Format(ModelState);
                    var msg = new Message<Domain.Operation.Entities.Projeto.PizzaSabores>();
                    msg.CreateMessageAlert("Regras de validação", lsVal);
                    return msg;
                }


            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.PizzaSabores>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao processar o endpoint Salvar PizzaSabores");
                return msg;
            }

        }

        /// <summary>
        /// Responsável por excluir empresa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(Delete))]
        [DisableCors]
        public async Task<Message<Domain.Operation.Entities.Projeto.PizzaSabores>> Delete(int id)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var objeto = new Domain.Operation.Commands.Projeto.DeletePizzaSabores() { IDPIZZA = id };
                    var response = await _mediator.Send(objeto);
                    return response;
                }
                else
                {
                    var lsVal = new List<string>();
                    lsVal = Validation.Format(ModelState);
                    var msg = new Message<Domain.Operation.Entities.Projeto.PizzaSabores>();
                    msg.CreateMessageAlert("Regras de validação", lsVal);
                    return msg;
                }


            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.PizzaSabores>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao processar o endpoint excluir PizzaSabores");
                return msg;
            }

        }
    }
}