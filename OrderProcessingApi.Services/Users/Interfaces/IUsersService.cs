using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Services.Users.Interfaces
{
    public interface IUsersService
    {
        public IEnumerable<UserResultDto> GetUsersQuery(UserQueryDto userQuery);
        public IEnumerable<UserGateway> CreateUsers(IEnumerable<UserDto> userDtos);
        public UserUpdateDto UpdateUser(UserUpdateDto userUpdateDto);

    }
}