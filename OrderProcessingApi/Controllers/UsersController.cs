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
    public IEnumerable<User> Create([FromBody] IEnumerable<User> users)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IEnumerable<User> Create([FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public IEnumerable<User> Get(string id, string auth0Id, DateTime dateLastModified, DateTime dateCreated)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public IEnumerable<User> Update([FromBody] IEnumerable<User> users)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public IEnumerable<User> Update([FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IEnumerable<User> Delete(string id, string auth0Id, DateTime dateLastModified, DateTime dateCreated)
    {
        throw new NotImplementedException();
    }
}