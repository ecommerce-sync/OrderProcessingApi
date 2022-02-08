using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Helpers;

namespace OrderProcessingApi.Services.Users;

public class UsersService : IUsersService
{
    private readonly IRepository _repository;

    public UsersService(IRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<User> GetUsersQuery(UserDto user)
    {
        if (user.DateLastModifiedFrom != null && user.DateLastModifiedTo != null && user.DateCreatedFrom != null &&
            user.DateCreatedTo != null)
        {
            var users = _repository.GetAll<User>().Where(u =>
                u.Id.ForceStringFromInt().Contains(user.Id.ForceStringFromInt()) &&
                u.Auth0Id.Contains(user.Auth0Id.ForceString()) &&
                DateTime.Compare(DateTime.Parse(user.DateLastModifiedFrom), u.DateLastModified) < 0 &&
                DateTime.Compare(DateTime.Parse(user.DateLastModifiedTo), u.DateLastModified) > 0 &&
                DateTime.Compare(DateTime.Parse(user.DateCreatedFrom), u.DateLastModified) < 0 &&
                DateTime.Compare(DateTime.Parse(user.DateCreatedTo), u.DateLastModified) > 0);
            return users;
        }

        if (user.DateLastModifiedFrom == null || user.DateLastModifiedTo == null || user.DateCreatedFrom == null ||
            user.DateCreatedTo == null)
        {
            var users = _repository.GetAll<User>().Where(u =>
                u.Id.ForceStringFromInt().Contains(user.Id.ForceStringFromInt()) &&
                u.Auth0Id.Contains(user.Auth0Id.ForceString()));
            return users;
        }

        throw new ArgumentException();
    }
}