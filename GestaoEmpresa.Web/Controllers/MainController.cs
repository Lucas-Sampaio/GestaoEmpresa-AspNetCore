using GestaoEmpresa.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GestaoEmpresa.Web.Controllers
{
    public abstract class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Mensagens.Any())
            {
                foreach (var item in response.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return true;
            }

            return false;
        }
    }
}
