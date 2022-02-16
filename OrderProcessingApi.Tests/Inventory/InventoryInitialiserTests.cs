using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Mappers;
using OrderProcessingApi.Services.Inventory;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Tests.Inventory;

[TestClass]
public class InventoryInitialiserTests : InMemoryRepositoryTests
{
    private IMapper? _mapper;
    private Mock<IWooInventoryService>? _mockWooInventoryService;
    private IInventoryInitialiser? _sut;

    [TestInitialize]
    public void Setup()
    {
        _mockWooInventoryService = new Mock<IWooInventoryService>();

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new IntegrationProfile()));
        _mapper = new Mapper(configuration);

        _sut = new InventoryInitialiser(_mockWooInventoryService.Object, _mapper);
    }

    [TestMethod]
    public void Initialize_ReturnsTrue_ValidWooIntegrationInput()
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
        var result = _sut!.Initialize(integrationDto, userId);

        //Assert
        _mockWooInventoryService!.Verify(x => x.AddInventoryItemsDb(It.IsAny<Integration>(), It.IsAny<int>()),
            Times.Once);
        Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void Initialize_ReturnsFalse_InvalidWooIntegrationInput()
    {
        //Arrange
        const string wooConsumerKey = "Test-WooConsumerKey-Invalid";
        const string wooConsumerSecret = "Test-WooConsumerSecret-Invalid";
        const string wooUrl = "Test-WooUrl-Invalid";
        const int userId = 1;

        var integrationDto = new IntegrationDto
        {
            WooConsumerKey = wooConsumerKey,
            WooConsumerSecret = wooConsumerSecret,
            WooUrl = wooUrl
        };

        _mockWooInventoryService!.Setup(x => x.AddInventoryItemsDb(It.IsAny<Integration>(), It.IsAny<int>()))
            .Throws(new JsonSerializationException());

        //Act
        var result = _sut.Initialize(integrationDto, userId);

        //Assert
        Assert.AreEqual(false, result);
    }
}