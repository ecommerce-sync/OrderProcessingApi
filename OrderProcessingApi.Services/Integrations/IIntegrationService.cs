using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Services.Integrations;

public interface IIntegrationService
{
    public Integration UpdateIntegration(IntegrationDto integration, int userId);
}