using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Services.Users
{
    public interface IUsersService
    {
        public IEnumerable<User> GetUsersQuery(UserQueryDto userQuery);
        public IEnumerable<UserGateway> CreateUsers(IEnumerable<UserDto> userDtos);
    }
}