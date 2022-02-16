using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Helpers.Exceptions;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Users;

public class UserValidationService : IUserValidationService
{
    private readonly IRepository _repository;

    public UserValidationService(IRepository repository)
    {
        _repository = repository;
    }

    public UserGateway ValidateUser(int? userId)
    {
        var user = _repository.GetAll<UserGateway>().FirstOrDefault(u => u.Id == userId);

        if (user == null) throw new InvalidUserException();

        return user;
    }
}

