using OrderProcessingApi.Domain.IntegrationProfiles;

namespace OrderProcessingApi.Services.ApiServices.Interfaces;

public interface IFetchWooApiService : IFetchApiServiceBase
{
    public void SetCredentials(WooIntegrationProfile setting);
}