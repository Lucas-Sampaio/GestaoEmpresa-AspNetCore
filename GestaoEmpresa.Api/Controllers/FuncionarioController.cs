using GestaoEmpresa.Api.Models;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.Dominio.Repositorio;
using GestaoEmpresa.Extensions.ConexaoApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/funcionario")]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        // GET: api/funcionario
        /// <summary>
        /// Retorna uma  lista de funcionarios
        /// </summary>
        /// <returns>Lista de funcionarios</returns>
        ///<response code="200">Retorna  uma lista de funcionarios</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FuncionarioDTO>))]
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();
            var dtos = funcionarios.Select(x => new FuncionarioDTO {Cpf = x.Cpf.Numero,Funcao = x.Funcao,Id = x.Id,Nome =x.Nome,Matricula = x.Matricula,Pis= x.Pis.Numero });
            return CustomResponse(dtos);
        }
        // GET: api/funcionario/5
        /// <summary>
        /// Retorna um funcionario encontrado pelo id
        /// </summary>
        /// <returns>funcionario</returns>
        ///<response code="200">Retorna  um funcionario</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FuncionarioDTO))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(id);
            var dto = new FuncionarioDTO
            {
                Cpf = funcionario.Cpf.Numero,
                Funcao = funcionario.Funcao,
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Matricula = funcionario.Matricula,
                Pis = funcionario.Pis.Numero,
                IdEmpresa = funcionario.IdEmpresa
            }; 
            return CustomResponse(dto);
        }
        // POST: api/funcionario
        /// <summary>
        /// Cria um objeto funcionario
        /// </summary>
        /// <param name="funcionarioDTO">um objeto funcionario</param>
        /// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = new Funcionario(funcionarioDTO.IdEmpresa, funcionarioDTO.Pis, funcionarioDTO.Matricula, funcionarioDTO.Funcao, funcionarioDTO.Nome, funcionarioDTO.Cpf);
            _funcionarioRepository.Adicionar(funcionario);
            var success = await _funcionarioRepository.UnitOfWork.Commit();

            return CustomResponse(success);
        }

        // PUT: api/funcionario/5
        /// <summary>
        /// Atualiza o objeto funcionario
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <param name="funcionarioDto">um objeto funcionario</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FuncionarioDTO funcionarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var funcionario = await _funcionarioRepository.ObterPorId(id);

            if (id != funcionarioDto.Id || funcionario == null)
            {
                AdicionarErroProcessamento("funcionario não encontrado");
                return CustomResponse();
            }
            funcionario.AtualizarFuncionario(funcionarioDto.Matricula, funcionarioDto.Funcao, funcionarioDto.Nome);
            _funcionarioRepository.Atualizar(funcionario);
            var success = await _funcionarioRepository.UnitOfWork.Commit();

            return CustomResponse(success);
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
            var funcionario = await _funcionarioRepository.ObterPorId(id);
            if (funcionario == null)
            {
                AdicionarErroProcessamento("funcionario não encontrada");
                return CustomResponse();
            }
            _funcionarioRepository.Remover(id);
            var success = await _funcionarioRepository.UnitOfWork.Commit();
            return CustomResponse(success);
        }



        //// POST: api/jornada
        ///// <summary>
        ///// Cria um objeto jornada de trabalho
        ///// </summary>
        ///// <param name="jornadaVMVal">um objeto jornada viewModelVAL</param>
        ///// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        ///// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        //[HttpPost("adicionarJornada")]
        //public async Task<IActionResult> AdicionarJornada([FromBody] JornadaVMVal jornadaVMVal)
        //{
        //    var result = ResponseApi<bool>.Instance;
        //    try
        //    {
        //        var jornada = AutoMapperManager.Instance.Map<JornadaTrabalho>(jornadaVMVal);
        //        _funcionarioRepository.AdicionarJornada(jornada);
        //        await _funcionarioRepository.UnitOfWork.Commit();
        //        result.SetResult(true);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(result.AddError(ex.Message).SetResult(false));
        //    }
        //}

        //// DELETE: api/jornada/5
        ///// <summary>
        ///// Deleta o objeto jornada de trabalho
        ///// </summary>
        ///// <param name="id">O id do objeto</param>
        ///// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        ///// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        //[HttpDelete("removerJornada/{id}")]
        //public async Task<IActionResult> RemoverJornada(int id)
        //{
        //    var result = ResponseApi<bool>.Instance;
        //    try
        //    {
        //        _funcionarioRepository.RemoverJornada(id);
        //        await _funcionarioRepository.UnitOfWork.Commit();
        //        result.SetResult(true);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(result.AddError(ex.Message).SetResult(false));
        //    }
        //}
    }
}
