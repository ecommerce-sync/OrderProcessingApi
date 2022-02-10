using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Services.ApiServices.Interfaces;

namespace OrderProcessingApi.Services.ApiServices;

public class FetchWooApiService : FetchApiServiceBase, IFetchWooApiService
{
    private WooIntegration _profile;

    public override HttpResponseMessage CallApi(string url)
    {
        var httpClient = new HttpClient();
        AddDefaultHeaders(httpClient);
        var response = httpClient.GetAsync(url);
        return response.Result;
    }

    public override HttpResponseMessage PostApi(string url, JsonContent jsonContent)
    {
        var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), $"{url}");
        requestMessage.Content = jsonContent;
        var httpClient = new HttpClient();
        AddDefaultHeaders(httpClient);

        var response = httpClient.SendAsync(requestMessage).Result;
        return response;
    }

    public void SetCredentials(WooIntegration profile)
    {
        _profile = profile;
    }

    private void AddDefaultHeaders(HttpClient httpClient)
    {
        var byteArray = Encoding.ASCII.GetBytes($"{_profile.ConsumerKey}:{_profile.ConsumerSecret}");
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    }
}