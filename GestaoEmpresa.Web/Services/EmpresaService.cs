using GestaoEmpresa.Web.Extensions;
using GestaoEmpresa.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Services
{
    public class EmpresaService : ServiceBase, IEmpresaService
    {
        private readonly HttpClient _httpClient;
        public EmpresaService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ApiGestaoUrl);
        }
        public async Task<ResponseResult> AtualizarEmpresa(int id, EmpresaVM empresaVM)
        {
            var content = ObterConteudo(empresaVM);
            var response = await _httpClient.PutAsync($"api/empresa/{id}", content);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }

        public async Task<ResponseResult> CadastrarEmpresa(EmpresaVM empresaVM)
        {
            var content = ObterConteudo(empresaVM);
            var response = await _httpClient.PostAsync("api/empresa/", content);
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }

        public async Task<EmpresaVM> ObterPorId(int id)
        {
            var response = await _httpClient.GetAsync($"api/empresa/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<EmpresaVM>(response);
        }

        public async Task<IEnumerable<EmpresaVM>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("api/empresa");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<IEnumerable<EmpresaVM>>(response);
        }

        public async Task<ResponseResult> RemoverEmpresa(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/empresa/{id}");
            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);
            return new ResponseResult();
        }
    }
}
