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
    public class PedidosController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Domain.Operation.Querys.Projeto.IQueryPedidos _queryPedidos;

        /// <summary>
        /// Construtor
        /// </summary>
        public PedidosController(IMediator mediator, Domain.Operation.Querys.Projeto.IQueryPedidos IQueryPedidos)
        {
            _mediator = mediator;
            _queryPedidos = IQueryPedidos;
        }

        /// <summary>
        /// Consulta de pessoas juridicas
        /// </summary>
        /// <param name="GetAllPedidos"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllPedidos))]
        public async Task<Message<List<Domain.Operation.Entities.Projeto.Pedidos>>> GetAllPedidos()
        {
            try
            {


                var response = await _queryPedidos.GetAllPedidos();
                return response;



            }
            catch (Exception ex)
            {
                var msg = new Message<List<Domain.Operation.Entities.Projeto.Pedidos>>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar Pedidos");
                return msg;
            }

        }

        /// <summary>
        /// Metodo responsável por obter o projeto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetByIDPedidos))]
        public async Task<Message<Domain.Operation.Entities.Projeto.Pedidos>> GetByIDPedidos(int id)
        {

            try
            {
                var response = await _queryPedidos.GetByIDPedidos(id);
                return response;
            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Pedidos>();
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
        public async Task<Message<Domain.Operation.Entities.Projeto.Pedidos>> Save([FromBody] Domain.Operation.Commands.Projeto.SavePedidos savePedidos)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(savePedidos);
                    return response;
                }
                else
                {
                    var lsVal = new List<string>();
                    lsVal = Validation.Format(ModelState);
                    var msg = new Message<Domain.Operation.Entities.Projeto.Pedidos>();
                    msg.CreateMessageAlert("Regras de validação", lsVal);
                    return msg;
                }


            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Pedidos>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao processar o endpoint Salvar Pedidos");
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
        public async Task<Message<Domain.Operation.Entities.Projeto.Pedidos>> Delete(int id)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var objeto = new Domain.Operation.Commands.Projeto.DeletePedidos() { IDPEDIDOS = id };
                    var response = await _mediator.Send(objeto);
                    return response;
                }
                else
                {
                    var lsVal = new List<string>();
                    lsVal = Validation.Format(ModelState);
                    var msg = new Message<Domain.Operation.Entities.Projeto.Pedidos>();
                    msg.CreateMessageAlert("Regras de validação", lsVal);
                    return msg;
                }


            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Pedidos>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao processar o endpoint excluir Pedidos");
                return msg;
            }

        }
    }
}