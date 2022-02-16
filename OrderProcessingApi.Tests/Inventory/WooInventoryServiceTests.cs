using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessingApi.Mappers;
using OrderProcessingApi.Services.ApiServices.Interfaces;
using OrderProcessingApi.Services.Inventory;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Tests.Inventory;

[TestClass]
public class WooInventoryServiceTests : InMemoryRepositoryTests
{
    private IWooInventoryService _sut;
    private Mock<IFetchWooApiService> _mockFetchWooApiService;
    private IMapper _mapper;

    [TestInitialize]
    public void Setup()
    {
        _mockFetchWooApiService = new Mock<IFetchWooApiService>();
        InMemoryRepository = new InMemoryRepository();

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new IntegrationProfile()));
        _mapper = new Mapper(configuration);

        //_sut = new WooInventoryService(_mockFetchWooApiService.Object, configuration, InMemoryRepository);
    }

    [TestMethod]
    public void TestMethod()
    {

    }

}