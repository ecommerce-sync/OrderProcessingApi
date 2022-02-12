using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Services.Users;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    public IEnumerable<UserGateway> Create([FromBody] IEnumerable<UserDto> users)
    {
        return _usersService.CreateUsers(users);
    }


    [HttpGet]
    public IEnumerable<UserResultDto> Get(string? auth0Id, DateTime? dateLastModifiedFrom, DateTime? dateLastModifiedTo,
        DateTime? dateCreatedFrom, DateTime? dateCreatedTo, int? userId)
    {
        var userDto = new UserQueryDto()
        {
            UserId = userId,
            Auth0Id = auth0Id,
            DateLastModifiedFrom = dateLastModifiedFrom,
            DateLastModifiedTo = dateLastModifiedTo,
            DateCreatedFrom = dateCreatedFrom,
            DateCreatedTo = dateCreatedTo
        };

        return _usersService.GetUsersQuery(userDto);
    }

    [HttpPatch]
    public UserUpdateDto Update([FromBody] UserUpdateDto userUpdate)
    {
        return _usersService.UpdateUser(userUpdate);
    }

    [HttpDelete]
    public IEnumerable<User> Delete(string id, string auth0Id, DateTime dateLastModifiedFrom, DateTime dateLastModifiedTo,
        DateTime dateCreatedFrom, DateTime dateCreatedTo)
    {
        throw new NotImplementedException();
    }
}