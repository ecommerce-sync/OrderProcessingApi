using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Services.Users.Interfaces;

public interface IUserValidationService
{
    public UserGateway ValidateUser(int userId);
}