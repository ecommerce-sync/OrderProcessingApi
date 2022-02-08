using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Services.Users;

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
    public IEnumerable<User> Create([FromBody] IEnumerable<UserDto> users)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IEnumerable<User> Create([FromBody] UserDto user)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IEnumerable<User> Get(int id, string auth0Id, string dateLastModifiedFrom, string dateLastModifiedTo,
        string dateCreatedFrom, string dateCreatedTo)
    {
        var userDto = new UserDto()
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
    public IEnumerable<User> Update([FromBody] IEnumerable<UserDto> users)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public IEnumerable<User> Update([FromBody] UserDto user)
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