using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Helpers.Exceptions;
using OrderProcessingApi.Services.Inventory.Interfaces;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IInventoryInitialiser _inventoryInitialiser;

    public UsersController(IUsersService usersService, IInventoryInitialiser inventoryInitialiser)
    {
        _usersService = usersService;
        _inventoryInitialiser = inventoryInitialiser;
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
    public ActionResult<UserUpdateDto> Update([FromBody] UserUpdateDto userUpdate)
    {
        try
        {
            //TODO Decide what happens when products not initialized
            if (!_inventoryInitialiser.Initialize(userUpdate.Integration, userUpdate.Id))
                return ValidationProblem("Problem with credentials");

            var user = _usersService.Update(userUpdate);
            return user;
        }

        catch (InvalidUserException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete]
    public IEnumerable<User> Delete(string id, string auth0Id, DateTime dateLastModifiedFrom, DateTime dateLastModifiedTo,
        DateTime dateCreatedFrom, DateTime dateCreatedTo)
    {
        throw new NotImplementedException();
    }
}