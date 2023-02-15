using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace NSE.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomRespose(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(s => s.Errors);
            foreach (var error in erros)
                AdicionarErroProcessamento(error.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomRespose(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AdicionarErroProcessamento(error.ErrorMessage);

            return CustomResponse();

        }
        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErros()
        {
            Erros.Clear();
        }
    }
}
