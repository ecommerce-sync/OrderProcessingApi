using OrderProcessingApi.Domain.Integrations;

namespace OrderProcessingApi.Services.ApiServices.Interfaces;

public interface IFetchWooApiService : IFetchApiServiceBase
{
    public void SetCredentials(Integration integration);
}