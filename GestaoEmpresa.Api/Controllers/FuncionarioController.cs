using GestaoEmpresa.Dominio;
using GestaoEmpresa.Dominio.Repositorio;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel;
using GestaoEmpresa.Extensions.AutoMapper;
using GestaoEmpresa.Extensions.ConexaoApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
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
                var funcionarios = await _funcionarioRepository.ObterTodos("Endereco", "Jornadas");
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
                var funcionario = await _funcionarioRepository.ObterPorId(id);
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
                var funcionario = await _funcionarioRepository.ObterPorId(id);
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
                _funcionarioRepository.Adicionar(funcionario);
                await _funcionarioRepository.UnitOfWork.Commit();
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
                _funcionarioRepository.Atualizar(funcionario);
                await _funcionarioRepository.UnitOfWork.Commit();
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
                var funcionario = await _funcionarioRepository.ObterPorId(id);
                if (funcionario == null)
                {
                    result.SetResult(false);
                    result.AddInfo("funcionario não encontrada", 404);
                    return Ok(result);
                }
                _funcionarioRepository.Remover(id);
                await _funcionarioRepository.UnitOfWork.Commit();
                result.SetResult(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }

        // POST: api/jornada
        /// <summary>
        /// Cria um objeto jornada de trabalho
        /// </summary>
        /// <param name="jornadaVMVal">um objeto jornada viewModelVAL</param>
        /// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpPost("adicionarJornada")]
        public async Task<IActionResult> AdicionarJornada([FromBody] JornadaVMVal jornadaVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var jornada = AutoMapperManager.Instance.Map<JornadaTrabalho>(jornadaVMVal);
                _funcionarioRepository.AdicionarJornada(jornada);
                await _funcionarioRepository.UnitOfWork.Commit();
                result.SetResult(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }

        // DELETE: api/jornada/5
        /// <summary>
        /// Deleta o objeto jornada de trabalho
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpDelete("removerJornada/{id}")]
        public async Task<IActionResult> RemoverJornada(int id)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                _funcionarioRepository.RemoverJornada(id);
                await _funcionarioRepository.UnitOfWork.Commit();
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
