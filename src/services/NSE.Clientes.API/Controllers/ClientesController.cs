using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    //[Route("api/clientes")]
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public ClientesController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("clientes")]
        public async Task<ActionResult> Index()
        {
            var resultado = await _mediator.EnviarComando(
                new RegistrarClienteCommand(Guid.NewGuid(), "André Oliveira Gomes", "inforoliver@gmail.com", "75274215335"));

            return CustomResponse(resultado);
        }
    }
}