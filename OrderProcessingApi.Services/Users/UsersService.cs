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
    private readonly IUserValidationService _userValidationService;

    public UsersService(IRepository repository, IMapper mapper, IUserValidationService userValidationService)
    {
        _repository = repository;
        _mapper = mapper;
        _userValidationService = userValidationService;
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

    public UserUpdateDto Update(UserUpdateDto userUpdateDto)
    {
        _userValidationService.ValidateUser(userUpdateDto.Id);

        var user = _repository.GetAll<UserGateway>().FirstOrDefault(u => u.Id == userUpdateDto.Id);

        var integrationGateway = _mapper.Map<IntegrationGateway>(userUpdateDto.Integration);

        user.Integrations.Add(integrationGateway);
        
        _repository.Update(user);
        _repository.Commit();
        return userUpdateDto;
    }

    public IEnumerable<UserResultDto> GetUsersQuery(UserQueryDto userQuery)
    {
        var users = _repository.GetAll<UserGateway>();
        if (userQuery.UserId != null) users = users.Where(u => u.Id == userQuery.UserId);

        if (userQuery.Auth0Id != null) users = users.Where(u => u.Auth0Id == userQuery.Auth0Id);

        if (userQuery.DateLastModifiedFrom != null && userQuery.DateLastModifiedTo != null)
        {
            users = users.Where(u => DateTime.Compare((DateTime)userQuery.DateLastModifiedFrom, u.DateLastModified) < 0);
            users = users.Where(u => DateTime.Compare((DateTime)userQuery.DateLastModifiedTo, u.DateLastModified) > 0);
        }

        // ReSharper disable once InvertIf
        if (userQuery.DateCreatedFrom != null && userQuery.DateCreatedTo != null)
        {
            users = users.Where(u => DateTime.Compare((DateTime)userQuery.DateCreatedFrom, u.DateLastModified) < 0);
            users = users.Where(u => DateTime.Compare((DateTime)userQuery.DateCreatedTo, u.DateLastModified) > 0);
        }

        var usersList = users.ToList();

        foreach (var user in usersList)
        {
            var integrations = _repository.GetAll<IntegrationGateway>().Where(u => u.UserId == user.Id).ToList();
            user.Integrations = _mapper.Map<List<IntegrationGateway>>(integrations);
        }

        var x = _mapper.Map<IEnumerable<UserResultDto>>(usersList);
        return _mapper.Map<IEnumerable<UserResultDto>>(usersList);
    }
}