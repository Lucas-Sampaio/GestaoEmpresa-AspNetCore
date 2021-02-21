using GestaoEmpresa.Web.Models;
using GestaoEmpresa.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Controllers
{
    public class EmpresaController : MainController
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            var model = await _empresaService.ObterTodos();
            return View(model);
        }

        // GET: Empresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpresaVM empresaVM)
        {
            if (!ModelState.IsValid) return View(empresaVM);

            var resposta = await _empresaService.CadastrarEmpresa(empresaVM);

            if (ResponsePossuiErros(resposta)) return View(empresaVM);
            return RedirectToAction(nameof(Index));
        }

        // GET: Empresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _empresaService.ObterPorId(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmpresaVM empresaVM)
        {
            if (id != empresaVM.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) return View(empresaVM);

            var resposta = await _empresaService.AtualizarEmpresa(id, empresaVM);

            if (ResponsePossuiErros(resposta)) return View(empresaVM);

            return RedirectToAction(nameof(Index));
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //em breve adicionar delete assincrono com sweetalert

            var resposta = await _empresaService.RemoverEmpresa(id);

            if (ResponsePossuiErros(resposta))
            {
                var erros = resposta.Errors.Mensagens;
                var msg = string.Join("<br/>", erros);
                return Json(new { success = false, msg });
            }

            return Json(new { success = true });

        }
    }
}