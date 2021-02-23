using GestaoEmpresa.Web.Extensions;
using GestaoEmpresa.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Services
{
    public class FuncionarioService : ServiceBase, IFuncionarioService
    {
        private readonly HttpClient _httpClient;
        public FuncionarioService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ApiGestaoUrl);
        }

        public async Task<ResponseResult> AdicionarJornada(JornadaTrabalhoVMVAL jornada)
        {
            var content = ObterConteudo(jornada);
            var response = await _httpClient.PostAsync("api/funcionario/adicionarJornada", content);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }

        public async Task<ResponseResult> AtualizarFuncionario(int id, FuncionarioVM FuncionarioVM)
        {

            var content = ObterConteudo(FuncionarioVM);
            var response = await _httpClient.PutAsync($"api/funcionario/{id}", content);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }

        public async Task<ResponseResult> CadastrarFuncionario(FuncionarioVM FuncionarioVM)
        {
            var content = ObterConteudo(FuncionarioVM);
            var response = await _httpClient.PostAsync("api/funcionario/", content);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }

        public async Task<FuncionarioVM> ObterPorId(int id)
        {
            var response = await _httpClient.GetAsync($"api/funcionario/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<FuncionarioVM>(response);
        }

        public async Task<IEnumerable<FuncionarioVM>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("api/funcionario");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<IEnumerable<FuncionarioVM>>(response);
        }

        public async Task<ResponseResult> RemoverFuncionario(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/funcionario/{id}");
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }

        public async Task<ResponseResult> RemoverJornada(int id,int jornadaId)
        {
            var response = await _httpClient.DeleteAsync($"api/funcionario/{id}/removerJornada/{jornadaId}");
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }
    }
}
