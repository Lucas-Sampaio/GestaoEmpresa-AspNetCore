using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEmpresa.DAL;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using GestaoEmpresa.Extensions.AutoMapper;
using GestaoEmpresa.Extensions.ConexaoApi;
using GestaoEmpresa.Repositorio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IRepositorio<Funcionario> _db;
        public FuncionarioController(GestaoContext pContext)
        {
            _db = new FuncionarioRepositorio(pContext);
        }
        
        // GET: api/funcionario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = ResponseApi<List<FuncionarioVM>>.Instance;
            try
            {
                var funcionarios = await _db.SelectAllAsync("Endereco", "Jornadas");
                var funcionarioVM = AutoMapperManager.Instance.Map<List<FuncionarioVM>>(funcionarios);
                result.SetResult(funcionarioVM);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }
        // GET: api/funcionario/5
        [HttpGet("{id}", Name = "GetFuncionario")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ResponseApi<FuncionarioVM>.Instance;
            try
            {
                var funcionario = await _db.SelectByIdAsync(id);
                var funcionarioVM = AutoMapperManager.Instance.Map<FuncionarioVM>(funcionario);
                result.SetResult(funcionarioVM);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }
        [HttpGet("getFuncionarioVal/{id}")]
        public async Task<IActionResult> GetEmpresaVal(int id)
        {
            var result = ResponseApi<FuncionarioVMVal>.Instance;
            try
            {
                var funcionario = await _db.SelectByIdAsync(id);
                var funcionarioVMVal = AutoMapperManager.Instance.Map<FuncionarioVMVal>(funcionario);
                result.SetResult(funcionarioVMVal);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }
        // POST: api/funcionario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuncionarioVMVal funcionarioVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var funcionario = AutoMapperManager.Instance.Map<Funcionario>(funcionarioVMVal);
                await _db.InsertAsync(funcionario);
                result.SetResult(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }

        // PUT: api/funcionario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FuncionarioVMVal funcionarioVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                if (id != funcionarioVMVal.Id)
                {
                    result.SetResult(false);
                    result.AddInfo("funcionario não encontrado", 404);
                    return Ok(result);
                }
                var funcionario = AutoMapperManager.Instance.Map<Funcionario>(funcionarioVMVal);
                await _db.UpdateAsync(funcionario);

                result.SetResult(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }


        // DELETE: api/funcionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var funcionario = _db.SelectById(id);
                if (funcionario == null)
                {
                    result.SetResult(false);
                    result.AddInfo("funcionario não encontrada", 404);
                    return Ok(result);
                }
                await _db.DeleteAsync(funcionario);
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
