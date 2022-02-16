using AutoMapper;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Services.Integrations;

public class IntegrationService : IIntegrationService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public IntegrationService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public Integration UpdateIntegration(IntegrationDto integrationDto, int userId)
    {
        var integration = _mapper.Map<Integration>(integrationDto);

        var newIntegrationGateway = _repository.GetAll<IntegrationGateway>().FirstOrDefault(i => i.UserId == userId) ?? new IntegrationGateway();
        var newIntegration = _mapper.Map<Integration>(newIntegrationGateway);

        newIntegration.WooConsumerKey = integration.WooConsumerKey;

        newIntegration.WooConsumerSecret = integration.WooConsumerSecret;

        newIntegration.WooUrl = integration.WooUrl;

        return newIntegration;
    }
}

