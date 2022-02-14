using System.Net.Http.Json;
using Newtonsoft.Json;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Services.ApiServices.Interfaces;

namespace OrderProcessingApi.Services.ApiServices;

public abstract class FetchApiServiceBase : IFetchApiServiceBase
{
    public T GetApiResponseJson<T>(string url)
    {
        var result = CallApi(url).Content.ReadAsStringAsync();
        return DeserializeApiResponseJson<T>(result.Result);
    }

    public abstract HttpResponseMessage CallApi(string url);
    public abstract HttpResponseMessage PostApi(string url, JsonContent jsonContent);

    private T DeserializeApiResponseJson<T>(string result)
    {
        return JsonConvert.DeserializeObject<T>(result);
    }
}