using OrderProcessingApi.Data.Interfaces;

namespace OrderProcessingApi.Services.Users;

public class UsersService : IUsersService
{
    private readonly IRepository _repository;
    public UsersService(IRepository repository)
    {
        _repository = repository;
    }
}