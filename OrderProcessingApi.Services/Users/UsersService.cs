using AutoMapper;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Services.Integrations;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Users;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly IUserValidationService _userValidationService;
    private readonly IIntegrationService _integrationService;

    public UsersService(IRepository repository, IMapper mapper, IUserValidationService userValidationService, IIntegrationService integrationService)
    {
        _repository = repository;
        _mapper = mapper;
        _userValidationService = userValidationService;
        _integrationService = integrationService;
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
            throw new ApplicationException(ex.ToString());
        }
    }

    public void Update(UserUpdateDto userUpdateDto)
    {
        var user = _userValidationService.ValidateUser(userUpdateDto.Id);

        var integration = _integrationService.UpdateIntegration(userUpdateDto.Integration, userUpdateDto.Id);

        var integrationGateway = _mapper.Map<IntegrationGateway>(integration);
        user.Integration = integrationGateway;

        _repository.Update(user);
        _repository.Commit();
    }

    public IEnumerable<UserResultDto> GetUsersQuery(UserQueryDto userQuery)
    {
        var users = _repository.GetAll<UserGateway>();
        if (userQuery.UserId != null) users = users.Where(u => u.Id == userQuery.UserId);

        if (userQuery.Auth0Id != null) users = users.Where(u => u.Auth0Id == userQuery.Auth0Id);

        if (userQuery.DateLastModifiedFrom != null && userQuery.DateLastModifiedTo != null)
        {
            users = users.Where(u =>
                DateTime.Compare((DateTime)userQuery.DateLastModifiedFrom, u.DateLastModified) < 0);
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
            var integration = _repository.GetAll<IntegrationGateway>().FirstOrDefault(u => u.UserId == user.Id);
            user.Integration = _mapper.Map<IntegrationGateway>(integration);
        }

        var x = _mapper.Map<IEnumerable<UserResultDto>>(usersList);
        return _mapper.Map<IEnumerable<UserResultDto>>(usersList);
    }
}