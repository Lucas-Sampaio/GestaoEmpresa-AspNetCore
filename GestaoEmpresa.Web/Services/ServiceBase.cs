using GestaoEmpresa.Web.Extensions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Services
{
    public class ServiceBase
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");
        }
        protected async ValueTask<T> DeserializarObjetoResponse<T>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    throw new CustomHttpRequestException(response.StatusCode);
                case HttpStatusCode.BadRequest:
                    return false;

            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
