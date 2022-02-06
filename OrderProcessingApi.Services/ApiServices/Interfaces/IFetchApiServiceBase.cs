using System.Net.Http.Json;

namespace OrderProcessingApi.Services.ApiServices.Interfaces
{
    public interface IFetchApiServiceBase
    {
        T GetApiResponseJson<T>(string url);
        HttpResponseMessage CallApi(string url);
        public HttpResponseMessage PostApi(string url, JsonContent jsonContent);
    }
}