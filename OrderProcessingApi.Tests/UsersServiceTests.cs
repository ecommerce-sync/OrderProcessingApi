using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Services.Users;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Tests;

[TestClass]
public class UsersServiceTests : InMemoryRepositoryTests
{
    private Mock<IMapper> _mockMapper;
    private Mock<IUserValidationService> _mockUserValidationService;
    private IUsersService _usersService;

    private UserUpdateDto _userUpdateDto = new UserUpdateDto
    {
        Id = 1,
        Integration = new IntegrationDto
        {
            WooConsumerKey = "Test-WooConsumerKey",
            WooConsumerSecret = "Test-WooConsumerSecret",
            WooUrl = "Test-WooUrl"
        }
    };

    private UserGateway _userGateway = new UserGateway()
    {
        Integration = new IntegrationGateway()
        {
            WooConsumerKey = "Test-WooConsumerKey",
            WooConsumerSecret = "Test-WooConsumerSecret",
            WooUrl = "Test-WooUrl"
        },
        Id = 1
    };

    [TestInitialize]
    public void Setup()
    {
        _mockMapper = new Mock<IMapper>();
        _mockUserValidationService = new Mock<IUserValidationService>();
        InMemoryRepository = new InMemoryRepository();

        _mockUserValidationService.Setup(x => x.ValidateUser(It.IsAny<int>())).Returns(_userGateway);

        _usersService = new UsersService(InMemoryRepository, _mockMapper.Object, _mockUserValidationService.Object);
    }

    [TestMethod]
    public void Update_NewUniqueIntegration()
    {
        var userUpdateDto = new UserUpdateDto
        {
            Id = 1,
            Integration = new IntegrationDto
            {
                WooConsumerKey = "Test-WooConsumerKey",
                WooConsumerSecret = "Test-WooConsumerSecret",
                WooUrl = "Test-WooUrl"
            }
        };

        _usersService.Update(userUpdateDto);
    }
}