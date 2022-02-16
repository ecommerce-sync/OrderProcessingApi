using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Mappers;
using OrderProcessingApi.Services.Integrations;

namespace OrderProcessingApi.Tests.Integrations;

[TestClass]
public class IntegrationServiceTests : InMemoryRepositoryTests
{
    private IIntegrationService _sut;
    private IMapper _mapper;

    [TestInitialize]
    public void Setup()
    {
        InMemoryRepository = new InMemoryRepository();

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new IntegrationProfile()));
        _mapper = new Mapper(configuration);

        _sut = new IntegrationService(InMemoryRepository, _mapper);
    }

    [TestMethod]
    public void UpdateIntegration_ReturnsIntegration_WooIntegrationInput_NoExistingIntegration()
    {
        //Arrange
        const string wooConsumerKey = "Test-WooConsumerKey";
        const string wooConsumerSecret = "Test-WooConsumerSecret";
        const string wooUrl = "Test-WooUrl";
        const int userId = 1;

        var integrationDto = new IntegrationDto
        {
            WooConsumerKey = wooConsumerKey,
            WooConsumerSecret = wooConsumerSecret,
            WooUrl = wooUrl
        };

        //Act
        var integrationResult = _sut.UpdateIntegration(integrationDto, userId);

        //Assert
        Assert.AreEqual(wooConsumerKey, integrationResult.WooConsumerKey);
        Assert.AreEqual(wooConsumerSecret, integrationResult.WooConsumerSecret);
        Assert.AreEqual(wooUrl, integrationResult.WooUrl);
    }

    [TestMethod]
    public void UpdateIntegration_ReturnsIntegration_WooIntegrationInput_ExistingIntegration()
    {
        //Arrange
        const string wooConsumerKey = "Test-WooConsumerKey";
        const string wooConsumerSecret = "Test-WooConsumerSecret";
        const string wooUrl = "Test-WooUrl";
        const int userId = 1;

        var integrationDto = new IntegrationDto
        {
            WooConsumerKey = wooConsumerKey,
            WooConsumerSecret = wooConsumerSecret,
            WooUrl = wooUrl
        };

        var integrationGateway = new IntegrationGateway()
        {
            UserId = userId,
            WooConsumerKey = wooConsumerKey,
            WooConsumerSecret = wooConsumerSecret,
            WooUrl = wooUrl
        };
        InMemoryRepository.Add(integrationGateway);

        //Act
        var integrationResult = _sut.UpdateIntegration(integrationDto, userId);

        //Assert
        Assert.AreEqual(wooConsumerKey, integrationResult.WooConsumerKey);
        Assert.AreEqual(wooConsumerSecret, integrationResult.WooConsumerSecret);
        Assert.AreEqual(wooUrl, integrationResult.WooUrl);
    }
}