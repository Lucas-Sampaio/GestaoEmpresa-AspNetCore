using GestaoEmpresa.Extensions.ConexaoApi;
using GestaoEmpresa.Web.Models;
using GestaoEmpresa.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult> Index()
        {
            var response = await _funcionarioService.ObterTodos();
            return View(response);
        }

        // GET: Funcionario/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Empresas = await GetEmpresas();
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FuncionarioVM funcionarioVM)
        {
            if (!ModelState.IsValid) { return View(funcionarioVM); }

            ViewBag.Empresas = await GetEmpresas();

            var resposta = await _funcionarioService.CadastrarFuncionario(funcionarioVM);
            if (ResponsePossuiErros(resposta)) return View(funcionarioVM);

            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Empresas = await GetEmpresas();
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
        public async Task<ActionResult> Edit(int id, FuncionarioVM funcionarioVM)
        {

            if (id != funcionarioVM.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid) { return View(funcionarioVM); }



            ViewBag.Empresas = await GetEmpresas();

            var resposta = await _funcionarioService.AtualizarFuncionario(id, funcionarioVM);
            if (ResponsePossuiErros(resposta)) return View(funcionarioVM);

            return RedirectToAction(nameof(Index));
        }
        // POST: Funcionario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
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
        //public async Task<ActionResult> CreateJornada(int? IdFuncionario)
        //{

        //    if (IdFuncionario == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(new JornadaVMVal() { IdFuncionario = IdFuncionario.Value });

        //}

        //// POST: Funcionario/CreateJornada
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateJornada(JornadaVMVal jornadaVMVal)
        //{

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var model = await WebApiRestClient.PostAsync<ResponseApi<bool>>("api/funcionario/adicionarJornada", jornadaVMVal);
        //            if (model.errors.Count > 0)
        //            {
        //                ViewBag.Erro = model.errors.First().msg;
        //                return View(jornadaVMVal);
        //            }
        //            return RedirectToAction(nameof(Edit), new { id = jornadaVMVal.IdFuncionario });
        //        }
        //        return View(jornadaVMVal);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Erro = ex.Message;
        //        return View(jornadaVMVal);
        //    }
        //}
        //public async Task<ActionResult> DeleteJornada(int? pId, int? IdFuncionario)
        //{
        //    try
        //    {
        //        if (pId == null)
        //        {
        //            throw new Exception("Id nulo");
        //        }
        //        var model = await WebApiRestClient.DeleteAsync<ResponseApi<bool>>($"api/funcionario/RemoverJornada/{pId}");
        //        if (model.errors.Count > 0)
        //        {
        //            ViewBag.Erro = model.errors.First().msg;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Erro = ex.Message;
        //    }
        //    return RedirectToAction(nameof(Edit), new { id = IdFuncionario });

        //}

    }
}