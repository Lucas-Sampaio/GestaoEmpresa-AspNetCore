using GestaoEmpresa.Api.Models;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.Dominio.Repositorio;
using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.Extensions.AutoMapper;
using GestaoEmpresa.Extensions.ConexaoApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Api.Controllers
{
    //[ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/empresa")]
    public class EmpresaController : MainController
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository produtoRepository)
        {
            _empresaRepository = produtoRepository;
        }
        // GET: api/Empresa
        /// <summary>
        /// Retorna uma  lista de empresas
        /// </summary>
        /// <returns>Lista de empresas</returns>
        ///<response code="200">Retorna uma lista de empresas</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Empresa>))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empresas = await _empresaRepository.ObterTodos();
            return CustomResponse(empresas);
        }

        // GET: api/Empresa/5
        /// <summary>
        /// Retorna uma empresa encontrada pelo id
        /// </summary>
        /// <returns>empresa</returns>
        ///<response code="200">Retorna uma empresa</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Empresa))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var empresa = await _empresaRepository.ObterPorId(id);
            return CustomResponse(empresa);
        }

        // POST: api/Empresa
        /// <summary>
        /// Cria um objeto empresa
        /// </summary>
        /// <param name="empresaDto">um objeto empresa</param>
        /// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna  true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaDTO empresaDto)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var empresa = new Empresa(empresaDto.Nome, empresaDto.Cnpj);
            _empresaRepository.Adicionar(empresa);
            var success = await _empresaRepository.UnitOfWork.Commit();
            return CustomResponse(success);
        }

        // PUT: api/Empresa/5
        /// <summary>
        /// Atualiza o objeto empresa
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <param name="empresaDto">um objeto empresa com seu id</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmpresaDTO empresaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != empresaDto.Id) AdicionarErroProcessamento("Empresa não corresponde a informada");

            var empresa = await _empresaRepository.ObterPorId(id);
            if (empresa == null) AdicionarErroProcessamento("Empresa não encontrada");

            empresa.AtualizarNome(empresaDto.Nome);
            empresa.AtualizarCnpj(empresaDto.Cnpj);

            _empresaRepository.Atualizar(empresa);
            var success = await _empresaRepository.UnitOfWork.Commit();

            return CustomResponse(success);

        }
        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deleta o objeto empresa
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empresa = await _empresaRepository.ObterPorId(id);
            if (empresa == null) AdicionarErroProcessamento("Empresa não encontrada");

            _empresaRepository.Remover(id);
            var success = await _empresaRepository.UnitOfWork.Commit();

            return Ok(success);

        }
    }
}
