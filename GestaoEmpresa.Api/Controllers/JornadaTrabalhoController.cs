using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEmpresa.DAL;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel;
using GestaoEmpresa.Extensions.AutoMapper;
using GestaoEmpresa.Extensions.ConexaoApi;
using GestaoEmpresa.Repositorio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/jornada")]
    [ApiController]
    public class JornadaTrabalhoController : ControllerBase
    {
        private readonly IRepositorio<JornadaTrabalho> _db;
        public JornadaTrabalhoController(GestaoContext pContext)
        {
            _db = new JornadaTrabalhoRepositorio(pContext);
        }

        // POST: api/jornada
        /// <summary>
        /// Cria um objeto jornada de trabalho
        /// </summary>
        /// <param name="jornadaVMVal">um objeto jornada viewModelVAL</param>
        /// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JornadaVMVal jornadaVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var jornada = AutoMapperManager.Instance.Map<JornadaTrabalho>(jornadaVMVal);
                await _db.InsertAsync(jornada);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var jornada = _db.SelectById(id);
                if (jornada == null)
                {
                    result.SetResult(false);
                    result.AddInfo("Não foi possivel realizar a operação", 404);
                    return Ok(result);
                }
                await _db.DeleteAsync(jornada);
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
