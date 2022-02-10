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
    public IEnumerable<User> Get(int id, string auth0Id, DateTime dateLastModifiedFrom, DateTime dateLastModifiedTo,
        DateTime dateCreatedFrom, DateTime dateCreatedTo)
    {
        var userDto = new UserQueryDto()
        {
            Id = id,
            Auth0Id = auth0Id,
            DateLastModifiedFrom = dateLastModifiedFrom,
            DateLastModifiedTo = dateLastModifiedTo,
            DateCreatedFrom = dateCreatedFrom,
            DateCreatedTo = dateCreatedTo
        };
        return _usersService.GetUsersQuery(userDto);
    }

    [HttpPut]
    public IEnumerable<User> Update([FromBody] IEnumerable<UserQueryDto> users)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IEnumerable<User> Delete(string id, string auth0Id, DateTime dateLastModifiedFrom, DateTime dateLastModifiedTo,
        DateTime dateCreatedFrom, DateTime dateCreatedTo)
    {
        throw new NotImplementedException();
    }
}