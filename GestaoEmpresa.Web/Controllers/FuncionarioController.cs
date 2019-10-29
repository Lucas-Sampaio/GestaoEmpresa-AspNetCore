﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using GestaoEmpresa.Extensions.ConexaoApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoEmpresa.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await WebApiRestClient.GetAsync<ResponseApi<List<FuncionarioVM>>>("api/funcionario");
                if (model.errors.Count > 0)
                {
                    ViewBag.Message = model.errors.FirstOrDefault().msg;
                    return View(new List<FuncionarioVM>());
                }
                return View(model.result);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(new List<FuncionarioVM>());
            }
        }

        // GET: Funcionario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var model = await WebApiRestClient.GetAsync<ResponseApi<FuncionarioVM>>($"api/funcionario/{id}");

                if (model.result == null)
                {
                    return NotFound();
                }

                if (model.errors.Count > 0)
                {
                    ViewBag.Message = model.errors.FirstOrDefault().msg;
                    return View(model);
                }

                return View(model.result);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Funcionario/Create
        public async Task<ActionResult> Create()
        {
            var response = await WebApiRestClient.GetAsync<ResponseApi<List<EmpresaVM>>>("api/empresa");
            var modelEmpresas = response.result;
            ViewBag.Empresas = new SelectList(modelEmpresas, "Id", "Nome");
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FuncionarioVMVal funcionarioVMVal)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var response = await WebApiRestClient.GetAsync<ResponseApi<List<EmpresaVM>>>("api/empresa");
                    var modelEmpresas = response.result;
                    ViewBag.Empresas = new SelectList(modelEmpresas, "Id", "Nome");

                    var model = await WebApiRestClient.PostAsync<ResponseApi<bool>>("api/funcionario", funcionarioVMVal);
                    if (model.errors.Count > 0)
                    {
                        ViewBag.Erro = model.errors.First().msg;
                        return View(funcionarioVMVal);
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(funcionarioVMVal);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(funcionarioVMVal);
            }
        }

        // GET: Funcionario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var response = await WebApiRestClient.GetAsync<ResponseApi<List<EmpresaVM>>>("api/empresa");
                var modelEmpresas = response.result;
                ViewBag.Empresas = new SelectList(modelEmpresas, "Id", "Nome");
                var model = await WebApiRestClient.GetAsync<ResponseApi<FuncionarioVMVal>>($"api/funcionario/getFuncionarioVal/{id.Value}");
                if (model == null)
                {
                    return NotFound();
                }
                return View(model.result);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, FuncionarioVMVal funcionarioVMVal)
        {
            try
            {
                if (id != funcionarioVMVal.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var response = await WebApiRestClient.GetAsync<ResponseApi<List<EmpresaVM>>>("api/empresa");
                    var modelEmpresas = response.result;
                    ViewBag.Empresas = new SelectList(modelEmpresas, "Id", "Nome");

                    var model = await WebApiRestClient.PutAsync<ResponseApi<bool>>($"api/funcionario/{id}", funcionarioVMVal);
                    if (model.errors.Count > 0)
                    {
                        ViewBag.Erro = model.errors.First().msg;
                        return View(funcionarioVMVal);
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(funcionarioVMVal);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(funcionarioVMVal);
            }
        }

        // GET: Funcionario/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await WebApiRestClient.GetAsync<ResponseApi<FuncionarioVM>>($"api/funcionario/{id}");

            if (model.result == null)
            {
                return NotFound();
            }

            return View(model.result);
        }

        // POST: Funcionario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var model = await WebApiRestClient.DeleteAsync<ResponseApi<bool>>($"api/funcionario/{id}");
                if (model.errors.Count > 0)
                {
                    ViewBag.Erro = model.errors.First().msg;
                    return RedirectToAction(nameof(Delete), new { id });
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
  
    }
}