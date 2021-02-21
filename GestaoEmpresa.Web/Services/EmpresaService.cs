using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.Extensions.ConexaoApi;
using GestaoEmpresa.Web.Extensions;
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
        public async Task<ResponseApi<bool>> AtualizarEmpresa(int id, EmpresaVM empresaVMVal)
        {
            var content = ObterConteudo(empresaVMVal);
            var response = await _httpClient.PutAsync($"api/empresa/{id}", content);
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseApi<bool>>(response);
        }

        public async Task<ResponseApi<bool>> CadastrarEmpresa(EmpresaVMVal empresaVMVal)
        {
            var content = ObterConteudo(empresaVMVal);
            var response = await _httpClient.PostAsync("api/empresa/", content);
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseApi<bool>>(response);
        }

        public async Task<ResponseApi<EmpresaVM>> ObterPorId(int id)
        {
            var response = await _httpClient.GetAsync($"api/empresa/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseApi<EmpresaVM>>(response);
        }

        public async Task<ResponseApi<IEnumerable<EmpresaVM>>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("api/empresa");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseApi<IEnumerable<EmpresaVM>>>(response);
        }

        public async Task<ResponseApi<bool>> RemoverEmpresa(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/empresa/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseApi<bool>>(response);
        }
    }
}
