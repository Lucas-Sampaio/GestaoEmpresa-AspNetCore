using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEmpresa.DAL;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.Extensions.AutoMapper;
using GestaoEmpresa.Extensions.ConexaoApi;
using GestaoEmpresa.Repositorio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IRepositorio<Empresa> _db;
        public EmpresaController(GestaoContext pContext)
        {
            _db = new EmpresaRepositorio(pContext);
        }
        // GET: api/Empresa
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = ResponseApi<List<EmpresaVM>>.Instance;
            try
            {
                var empresas = await _db.SelectAllAsync("Endereco", "Funcionarios");
                var empresasVM = AutoMapperManager.Instance.Map<List<EmpresaVM>>(empresas);
                result.SetResult(empresasVM);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }

        // GET: api/Empresa/5
        // GET: api/Empresa/5
        [HttpGet("{id}", Name = "GetEmpresa")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ResponseApi<EmpresaVM>.Instance;
            try
            {
                var empresa = await _db.SelectByIdAsync(id);
                var empresaVM = AutoMapperManager.Instance.Map<EmpresaVM>(empresa);
                result.SetResult(empresaVM);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }
        [HttpGet("getEmpresaVal/{id}")]
        public async Task<IActionResult> GetEmpresaVal(int id)
        {
            var result = ResponseApi<EmpresaVMVal>.Instance;
            try
            {
                var empresa = await _db.SelectByIdAsync(id);
                var empresaVMVal = AutoMapperManager.Instance.Map<EmpresaVMVal>(empresa);
                result.SetResult(empresaVMVal);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }
        // POST: api/Empresa
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaVMVal empresaVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var empresa = AutoMapperManager.Instance.Map<Empresa>(empresaVMVal);
                await _db.InsertAsync(empresa);
                result.SetResult(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmpresaVMVal empresaVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                if (id != empresaVMVal.Id)
                {
                    result.SetResult(false);
                    result.AddInfo("empresa não encontrada", 404);
                    return Ok(result);
                }
                var empresa = AutoMapperManager.Instance.Map<Empresa>(empresaVMVal);
                await _db.UpdateAsync(empresa);

                result.SetResult(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var empresa = _db.SelectById(id);
                if (empresa == null)
                {
                    result.SetResult(false);
                    result.AddInfo("empresa não encontrada", 404);
                    return Ok(result);
                }
                await _db.DeleteAsync(empresa);
                result.SetResult(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }
    }
}
