using AutoMapper;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Helpers;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Users;

public class UsersService : IUsersService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public UsersService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<User> GetUsersQuery(UserQueryDto userQuery)
    {
        if (userQuery.DateLastModifiedFrom != null && userQuery.DateLastModifiedTo != null && userQuery.DateCreatedFrom != null &&
            userQuery.DateCreatedTo != null)
        {
            var users = _repository.GetAll<User>().Where(u =>
                u.Id.ForceStringFromInt().Contains(userQuery.Id.ForceStringFromInt()) &&
                u.Auth0Id.Contains(userQuery.Auth0Id.ForceString()) &&
                DateTime.Compare(userQuery.DateLastModifiedFrom ?? new DateTime(), u.DateLastModified) < 0 &&
                DateTime.Compare(userQuery.DateLastModifiedTo ?? new DateTime(), u.DateLastModified) > 0 &&
                DateTime.Compare(userQuery.DateCreatedFrom ?? new DateTime(), u.DateLastModified) < 0 &&
                DateTime.Compare(userQuery.DateCreatedTo ?? new DateTime(), u.DateLastModified) > 0);
            return users;
        }

        if (userQuery.DateLastModifiedFrom == null || userQuery.DateLastModifiedTo == null || userQuery.DateCreatedFrom == null ||
            userQuery.DateCreatedTo == null)
        {
            var users = _repository.GetAll<User>().Where(u =>
                u.Id.ForceStringFromInt().Contains(userQuery.Id.ForceStringFromInt()) &&
                u.Auth0Id.Contains(userQuery.Auth0Id.ForceString()));
            return users;
        }

        throw new ArgumentException();
    }

    public IEnumerable<UserGateway> CreateUsers(IEnumerable<UserDto> userDtos)
    {
        var users = _mapper.Map<List<UserGateway>>(userDtos);
        try
        {
            _repository.AddRange(users);
            _repository.Commit();
            return users;
        }
        catch (Exception ex)
        {
            //TODO Handle specific exceptions
            throw new ApplicationException(message: ex.ToString());
        }
        
    }
}