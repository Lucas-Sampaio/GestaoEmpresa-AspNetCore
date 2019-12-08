using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoEmpresa.Extensions.ConexaoApi
{
    public class WebApiRestClient
    {
        private static readonly Uri ServerUri = new Uri("http://localhost:58823");

        public static async Task<T> GetAsync<T>(string resourceUri, [Optional]CancellationToken cancellationToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = ServerUri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    var response = await client.GetAsync(resourceUri, cancellationToken);
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<T>();
                    return default(T);
                }
            }
            catch (TaskCanceledException cancelEx)
            {
                throw new Exception("A tarefa demorou muito para responder e foi cancelada.", cancelEx);
            }
            catch (Exception ex)
            {
                throw new Exception("GetAsync erro.", ex);
            }

        }

        public static async Task<T> PostAsync<T>(string resourceUri, object pObject)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = ServerUri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP POST
                    var response = await client.PostAsJsonAsync(resourceUri, pObject);
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<T>();
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PostAsync erro.", ex);
            }
        }
        public static async Task<T> PutAsync<T>(string resourceUri, object pObject)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = ServerUri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP PUT
                    var response = await client.PutAsJsonAsync(resourceUri, pObject);
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<T>();
                    return default(T);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("PutAsync erro.", ex);
            }
        }
        public static async Task<T> DeleteAsync<T>(string resourceUri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = ServerUri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP DELETE
                    var response = await client.DeleteAsync(resourceUri);
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsAsync<T>();
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteAsync erro.", ex);
            }

        }
    }
}
