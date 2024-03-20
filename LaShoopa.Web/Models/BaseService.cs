using LaShoopa.Web.Models.DTOs;
using LaShoopa.Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace LaShoopa.Web.Models
{
    public class BaseService : IBaseService
    {
        public ResponceDTO ResponceModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory client)
        {
            ResponceModel = new ResponceDTO();
            httpClient = client;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("LaShoopaAPI");

                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.Headers.Add("Accept", "application/json");
                    request.RequestUri = new Uri(apiRequest.Url);
                    client.DefaultRequestHeaders.Clear();

                    if (apiRequest.Data != null)
                        request.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                            Encoding.UTF8, "application/json");

                    HttpResponseMessage responce = null;

                    switch (apiRequest.ApiType)
                    {
                        case SD.ApiType.POST:
                            request.Method = HttpMethod.Post;
                            break;
                        case SD.ApiType.PUT:
                            request.Method = HttpMethod.Put;
                            break;
                        case SD.ApiType.DELETE:
                            request.Method = HttpMethod.Delete;
                            break;
                        default:
                            request.Method = HttpMethod.Get;
                            break;
                    }

                    responce = await client.SendAsync(request);

                    var apiContent = await responce.Content.ReadAsStringAsync();
                    var responceDTO = JsonConvert.DeserializeObject<T>(apiContent);
                    return responceDTO;
                }

            }
            catch (Exception ex)
            {
                var dto = new ResponceDTO()
                {
                    IsSuccess = false,
                    Error = "BaseService Error",
                    Message = new List<string> { ex.Message }
                };

                var res = JsonConvert.SerializeObject(dto);
                var responceDTO = JsonConvert.DeserializeObject<T>(res);
                return responceDTO;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
