using GestaoEmpresa.DAL;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using GestaoEmpresa.Extensions.AutoMapper;
using GestaoEmpresa.Extensions.ConexaoApi;
using GestaoEmpresa.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoEmpresa.Repositorio.RepositorioComum;

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
        /// <summary>
        /// Retorna uma ResponseApi com lista de funcionarios
        /// </summary>
        /// <returns>Lista de funcionarios viewmodels</returns>
        ///<response code="200">Retorna um Response api com o result contendo uma lista de funcionarios ou um response com msg de erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<List<FuncionarioVM>>))]
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
        /// <summary>
        /// Retorna uma ResponseApi com um funcionario encontrado pelo id
        /// </summary>
        /// <returns>Lista de funcionarios viewmodels</returns>
        ///<response code="200">Retorna um Response api com o result contendo um funcionario ou um response com msg de erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<FuncionarioVM>))]
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
        /// <summary>
        /// Retorna um ResponseApi com um funcionario encontrado pelo id
        /// </summary>
        /// <returns>Lista de funcionarios viewmodels</returns>
        ///<response code="200">Retorna um funcionairio para validação para caso de atualização</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<FuncionarioVMVal>))]
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
        /// <summary>
        /// Cria um objeto funcionario
        /// </summary>
        /// <param name="funcionarioVMVal">um objeto funcionario viewModelVAL</param>
        /// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
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
        /// <summary>
        /// Atualiza o objeto funcionario
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <param name="funcionarioVMVal">um objeto funcionario viewModelVAL</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
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
        /// <summary>
        /// Deleta o objeto funcionario
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
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
