using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Domain.IntegrationProfiles;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Services.Inventory.Interfaces;
using Integration = OrderProcessingApi.Domain.Integrations.Integration;

namespace OrderProcessingApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public ProductsController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpPost]
    public IEnumerable<UserGateway> Create([FromBody] IEnumerable<UserDto> users)
    {
        return _inventoryService.CreateProduct(users);
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        var inventoryItems = new List<Product>();
        var profile = new Integration
        {
            Id = 1,
            WooIntegration = new WooIntegration
            {
                Id = 1,
                ConsumerKey = "ck_0c436b3a21352f0298a30a683dc020fe4deed527",
                ConsumerSecret = "cs_090854fa655720b1ec5318861fde1e400eec8c27",
                Url = "https://benparr.tech/blog/"
            }
        };
        _inventoryService.AddInventoryItems(inventoryItems, profile);
        return inventoryItems;
    }

    [HttpPatch]
    public Product Update()
    {
        throw new NotImplementedException();
    }
}