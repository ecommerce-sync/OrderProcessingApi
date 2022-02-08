using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Services.Users
{
    public interface IUsersService
    {
        public IEnumerable<User> GetUsersQuery(UserDto user);
    }
}