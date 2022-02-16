using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Mappers;
using OrderProcessingApi.Services.Integrations;
using OrderProcessingApi.Services.Users;
using OrderProcessingApi.Services.Users.Interfaces;
using System;
using System.Linq;

namespace OrderProcessingApi.Tests.Users;

[TestClass]
public class UsersServiceTests : InMemoryRepositoryTests
{
    private IMapper _mapper;
    private Mock<IUserValidationService> _mockUserValidationService;
    private Mock<IIntegrationService> _mockIntegrationService;
    private IUsersService _sut;

    [TestInitialize]
    public void Setup()
    {
        _mockUserValidationService = new Mock<IUserValidationService>();
        _mockIntegrationService = new Mock<IIntegrationService>();
        InMemoryRepository = new InMemoryRepository();

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new IntegrationProfile()));
        _mapper = new Mapper(configuration);


        _sut = new UsersService(InMemoryRepository, _mapper, _mockUserValidationService.Object, _mockIntegrationService.Object);
    }

    [TestMethod]
    public void Update_NewUniqueIntegration()
    {
        //Arrange
        const string wooConsumerKey = "Test-WooConsumerKey";
        const string wooConsumerSecret = "Test-WooConsumerSecret";
        const string wooUrl = "Test-WooUrl";
        const string auth0Id = "Test-AuthId";

        // Set up IntegrationService mock
        var userUpdateDto = new UserUpdateDto
        {
            Id = 1,
            Integration = new IntegrationDto
            {
                WooConsumerKey = wooConsumerKey,
                WooConsumerSecret = wooConsumerSecret,
                WooUrl = wooUrl
            }
        };

        // Set up UserValidationService mock
        var userGateway = new UserGateway()
        {
            Id = 1,
            Auth0Id = auth0Id,
            DateCreated = DateTime.Now,
            DateLastModified = DateTime.Now
        };
        _mockUserValidationService.Setup(x => x.ValidateUser(It.IsAny<int>())).Returns(userGateway);

        var integration = new Integration()
        {
            WooConsumerKey = wooConsumerKey,
            WooConsumerSecret = wooConsumerSecret,
            WooUrl = wooUrl
        };
        _mockIntegrationService.Setup(x => x.UpdateIntegration(It.IsAny<IntegrationDto>(), It.IsAny<int>())).Returns(integration);

        InMemoryRepository.Add(userGateway);

        //Act
        _sut.Update(userUpdateDto);

        //Assert
        var integrationResult = InMemoryRepository.GetAll<UserGateway>().FirstOrDefault(u => u.Id == 1)!.Integration;
        Assert.AreEqual(userUpdateDto.Integration.WooConsumerKey, integrationResult.WooConsumerKey);
        Assert.AreEqual(userUpdateDto.Integration.WooConsumerSecret, integrationResult.WooConsumerSecret);
        Assert.AreEqual(userUpdateDto.Integration.WooUrl, integrationResult.WooUrl);
    }
}