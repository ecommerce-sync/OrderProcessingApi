using AutoMapper;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Users;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
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
            throw new ApplicationException(ex.ToString());
        }
    }

    public UserUpdateDto Update(UserUpdateDto userUpdateDto)
    {
        var user = _userValidationService.ValidateUser(userUpdateDto.Id);

        var userIntegration = _repository.GetAll<IntegrationGateway>().FirstOrDefault(i => i.UserId == userUpdateDto.Id) ?? new IntegrationGateway();

        //TODO Integration update service to remove this logic
        var wooConsumerKey = userUpdateDto.Integration.WooConsumerKey;
        if (wooConsumerKey != null) userIntegration.WooConsumerKey = wooConsumerKey;

        var wooConsumerSecret = userUpdateDto.Integration.WooConsumerSecret;
        if (wooConsumerSecret != null) userIntegration.WooConsumerSecret = wooConsumerSecret;

        var wooUrl = userUpdateDto.Integration.WooUrl;
        if (wooUrl != null) userIntegration.WooUrl = wooUrl;

        // Set the new Integrations for the user
        var integrationGateway = _mapper.Map<IntegrationGateway>(userUpdateDto.Integration);
        user.Integration = userIntegration;

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