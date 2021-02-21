using FluentValidation.Results;
using GestaoEmpresa.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace GestaoEmpresa.Api.Controllers
{

    [ApiController]
    public class MainController : ControllerBase
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", Erros.ToArray()}
            }));
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var item in erros)
            {
                AdicionarErroProcessamento(item.ErrorMessage);
            }

            return CustomResponse();
        }
        protected ActionResult CustomResponse(ResponseResult response)
        {
            ResponsePossuiErros(response);

            return CustomResponse();
        }
        protected ActionResult CustomResponse(ValidationResult validationsResult)
        {
            foreach (var item in validationsResult.Errors)
            {
                AdicionarErroProcessamento(item.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response == null || !response.Errors.Mensagens.Any()) return false;
            foreach (var item in response.Errors.Mensagens)
            {
                AdicionarErroProcessamento(item);
            }
            return true;
        }
        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }
    }
}
