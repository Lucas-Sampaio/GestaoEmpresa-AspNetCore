using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.Extensions.ConexaoApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await WebApiRestClient.GetAsync<ResponseApi<List<EmpresaVM>>>("api/empresa");
                if (model.errors.Count > 0)
                {
                    ViewBag.Message = model.errors.FirstOrDefault().msg;
                    return View(new List<EmpresaVM>());
                }
                return View(model.result);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(new List<EmpresaVM>());
            }
        }

        // GET: Empresa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var model = await WebApiRestClient.GetAsync<ResponseApi<EmpresaVM>>($"api/empresa/{id}");

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

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmpresaVMVal empresaVMVal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = await WebApiRestClient.PostAsync<ResponseApi<bool>>("api/empresa", empresaVMVal);
                    if (model.errors.Count > 0)
                    {

                        ViewBag.Erro = model.errors.First().msg;
                        return View(empresaVMVal);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }
            return View(empresaVMVal);
        }

        // GET: Empresa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var model = await WebApiRestClient.GetAsync<ResponseApi<EmpresaVMVal>>($"api/empresa/getEmpresaVal/{id.Value}");
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

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmpresaVMVal empresaVMVal)
        {
            try
            {
                if (id != empresaVMVal.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var model = await WebApiRestClient.PutAsync<ResponseApi<bool>>($"api/empresa/{id}", empresaVMVal);
                    if (model.errors.Count > 0)
                    {
                        ViewBag.Erro = model.errors.First().msg;
                        return View(empresaVMVal);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }
            return View(empresaVMVal);
        }

        // GET: Empresa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await WebApiRestClient.GetAsync<ResponseApi<EmpresaVM>>($"api/empresa/{id}");

            if (model.result == null)
            {
                return NotFound();
            }

            return View(model.result);
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var model = await WebApiRestClient.DeleteAsync<ResponseApi<bool>>($"api/empresa/{id}");
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
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }
    }
}