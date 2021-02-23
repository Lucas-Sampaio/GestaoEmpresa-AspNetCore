using GestaoEmpresa.Web.Models;
using GestaoEmpresa.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Controllers
{
    public class FuncionarioController : MainController
    {

        private readonly IFuncionarioService _funcionarioService;
        private readonly IEmpresaService _empresaService;
        public FuncionarioController(IFuncionarioService funcionarioService, IEmpresaService empresaService)
        {
            _funcionarioService = funcionarioService;
            _empresaService = empresaService;
        }

        private async Task<SelectList> GetEmpresas()
        {
            var response = await _empresaService.ObterTodos();
            return new SelectList(response, "Id", "Nome");
        }
        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var response = await _funcionarioService.ObterTodos();
            return View(response);
        }

        // GET: Funcionario/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Empresas = await GetEmpresas();
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioVM funcionarioVM)
        {
            ViewBag.Empresas = await GetEmpresas();

            if (!ModelState.IsValid) { return View(funcionarioVM); }

            var resposta = await _funcionarioService.CadastrarFuncionario(funcionarioVM);
            if (ResponsePossuiErros(resposta)) return View(funcionarioVM);

            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Empresas = await GetEmpresas();

            if (id == null)
            {
                return NotFound();
            }

            var model = await _funcionarioService.ObterPorId(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FuncionarioVM funcionarioVM)
        {

            ViewBag.Empresas = await GetEmpresas();

            if (id != funcionarioVM.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) { return View(funcionarioVM); }

            var resposta = await _funcionarioService.AtualizarFuncionario(id, funcionarioVM);
            if (ResponsePossuiErros(resposta)) return View(funcionarioVM);

            return RedirectToAction(nameof(Index));
        }
        // POST: Funcionario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var resposta = await _funcionarioService.RemoverFuncionario(id);

            if (ResponsePossuiErros(resposta))
            {
                var erros = resposta.Errors.Mensagens;
                var msg = string.Join("<br/>", erros);
                return Json(new { success = false, msg });
            }

            return Json(new { success = true });
        }
        public IActionResult CreateJornada(int? IdFuncionario)
        {
            if (IdFuncionario == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(new JornadaTrabalhoVMVAL() { IdFuncionario = IdFuncionario.Value });

        }

        // POST: Funcionario/CreateJornada
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJornada(JornadaTrabalhoVMVAL jornadaVMVal)
        {
            if (!ModelState.IsValid) { return View(jornadaVMVal); }

            var resposta = await _funcionarioService.AdicionarJornada(jornadaVMVal);

            if (ResponsePossuiErros(resposta)) return View(jornadaVMVal);

            return RedirectToAction(nameof(Edit), new { id = jornadaVMVal.IdFuncionario });

        }
        public async Task<IActionResult> DeleteJornada(int? pId, int? IdFuncionario)
        {

            if (pId == null)
            {
                return Json(new { success = false, msg = "Id nulo" });
            }
            var resposta = await _funcionarioService.RemoverJornada(IdFuncionario.Value, pId.Value);

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