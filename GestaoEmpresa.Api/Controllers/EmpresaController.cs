﻿using GestaoEmpresa.Dominio;
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
    [ApiController]

    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository produtoRepository)
        {
            _empresaRepository = produtoRepository;
        }
        // GET: api/Empresa
        /// <summary>
        /// Retorna uma ResponseApi com lista de empresas
        /// </summary>
        /// <returns>Lista de empresas viewmodels</returns>
        ///<response code="200">Retorna um Response api com o result contendo uma lista de empresas ou um response com msg de erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<List<EmpresaVM>>))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = ResponseApi<List<EmpresaVM>>.Instance;
            try
            {
                var empresas = await _empresaRepository.ObterTodos("Endereco", "Funcionarios");
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
        /// <summary>
        /// Retorna uma ResponseApi com uma empresa encontrada pelo id
        /// </summary>
        /// <returns>Lista de empresas viewmodels</returns>
        ///<response code="200">Retorna um Response api com o result contendo uma empresa ou um response com msg de erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<EmpresaVM>))]
        [HttpGet("{id}", Name = "GetEmpresa")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ResponseApi<EmpresaVM>.Instance;
            try
            {
                var empresa = await _empresaRepository.ObterPorId(id);
                var empresaVM = AutoMapperManager.Instance.Map<EmpresaVM>(empresa);
                result.SetResult(empresaVM);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message));
            }
        }
        /// <summary>
        /// Retorna uma ResponseApi com uma empresa encontrada pelo id
        /// </summary>
        /// <returns>Lista de empresas viewmodels</returns>
        ///<response code="200">Retorna uma empresa para validação para caso de atualização</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<EmpresaVMVal>))]
        [HttpGet("getEmpresaVal/{id}")]
        public async Task<IActionResult> GetEmpresaVal(int id)
        {
            var result = ResponseApi<EmpresaVMVal>.Instance;
            try
            {
                var empresa = await _empresaRepository.ObterPorId(id);
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
        /// <summary>
        /// Cria um objeto empresa
        /// </summary>
        /// <param name="empresaVMVal">um objeto empresa viewModelVAL</param>
        /// <returns>retorna true se o objeto foi criado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaVMVal empresaVMVal)
        {
            var result = ResponseApi<bool>.Instance;
            try
            {
                var empresa = AutoMapperManager.Instance.Map<Empresa>(empresaVMVal);
                _empresaRepository.Adicionar(empresa);
                await _empresaRepository.UnitOfWork.Commit();
                result.SetResult(true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
        }

        // PUT: api/Empresa/5
        /// <summary>
        /// Atualiza o objeto empresa
        /// </summary>
        /// <param name="id">O id do objeto</param>
        /// <param name="empresaVMVal">um objeto empresa viewModelVAL</param>
        /// <returns>retorna true se o objeto foi atualizado com exito e false caso ocorra algum erro</returns>
        /// <response code="200">retorna uma responseApi com o result true se o objeto foi criado com exito e false caso ocorra algum erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseApi<bool>))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmpresaVM empresaVMVal)
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
                _empresaRepository.Atualizar(empresa);
                await _empresaRepository.UnitOfWork.Commit();
                result.SetResult(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(result.AddError(ex.Message).SetResult(false));
            }
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
            var result = ResponseApi<bool>.Instance;
            try
            {
                var empresa = await _empresaRepository.ObterPorId(id);
                if (empresa == null)
                {
                    result.SetResult(false);
                    result.AddInfo("empresa não encontrada", 404);
                    return Ok(result);
                }
                _empresaRepository.Remover(id);
                await _empresaRepository.UnitOfWork.Commit();
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
