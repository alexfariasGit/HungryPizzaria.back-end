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
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Domain.Operation.Querys.Projeto.IQueryCliente _queryCliente;

        /// <summary>
        /// Construtor
        /// </summary>
        public ClienteController(IMediator mediator, Domain.Operation.Querys.Projeto.IQueryCliente IQueryCliente)
        {
            _mediator = mediator;
            _queryCliente = IQueryCliente;
        }

        /// <summary>
        /// Consulta de pessoas juridicas
        /// </summary>
        /// <param name="GetAllCliente"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllCliente))]
        public async Task<Message<List<Domain.Operation.Entities.Projeto.Cliente>>> GetAllCliente()
        {
            try
            {


                var response = await _queryCliente.GetAllCliente();
                return response;



            }
            catch (Exception ex)
            {
                var msg = new Message<List<Domain.Operation.Entities.Projeto.Cliente>>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao pesquisar Cliente");
                return msg;
            }

        }

        /// <summary>
        /// Metodo responsável por obter o projeto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetByIDCliente))]
        public async Task<Message<Domain.Operation.Entities.Projeto.Cliente>> GetByIDCliente(int id)
        {

            try
            {
                var response = await _queryCliente.GetByIDCliente(id);
                return response;
            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Cliente>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao obter o cliente");
                return msg;
            }


        }

        /// <summary>
        /// Metodo responsável por obter o projeto pelo ID
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetByTelefoneCliente))]
        public async Task<Message<Domain.Operation.Entities.Projeto.Cliente>> GetByTelefoneCliente(string telefone)
        {

            try
            {
                var response = await _queryCliente.GetByTelefoneCliente(telefone);
                return response;
            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Cliente>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao obter o cliente");
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
        public async Task<Message<Domain.Operation.Entities.Projeto.Cliente>> Save([FromBody] Domain.Operation.Commands.Projeto.SaveCliente saveCliente)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(saveCliente);
                    return response;
                }
                else
                {
                    var lsVal = new List<string>();
                    lsVal = Validation.Format(ModelState);
                    var msg = new Message<Domain.Operation.Entities.Projeto.Cliente>();
                    msg.CreateMessageAlert("Regras de validação", lsVal);
                    return msg;
                }


            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Cliente>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao processar o endpoint Salvar Cliente");
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
        public async Task<Message<Domain.Operation.Entities.Projeto.Cliente>> Delete(int id)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var objeto = new Domain.Operation.Commands.Projeto.DeleteCliente() { IDCLIENTE = id };
                    var response = await _mediator.Send(objeto);
                    return response;
                }
                else
                {
                    var lsVal = new List<string>();
                    lsVal = Validation.Format(ModelState);
                    var msg = new Message<Domain.Operation.Entities.Projeto.Cliente>();
                    msg.CreateMessageAlert("Regras de validação", lsVal);
                    return msg;
                }


            }
            catch (Exception ex)
            {
                var msg = new Message<Domain.Operation.Entities.Projeto.Cliente>();
                msg.CreateMessageError("Erro", ex, "Ocorreu um erro ao processar o endpoint excluir Cliente");
                return msg;
            }

        }
    }
}