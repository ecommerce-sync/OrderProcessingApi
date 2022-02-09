using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.IntegrationProfiles;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        var inventoryItems = new List<Product>();
        var profile = new IntegrationProfile
        {
            Id = 1,
            WooIntegrationProfile = new WooIntegrationProfile
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
}