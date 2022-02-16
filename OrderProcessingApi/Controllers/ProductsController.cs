using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Helpers.Exceptions;
using OrderProcessingApi.Services.Inventory.Interfaces;
using Integration = OrderProcessingApi.Domain.Integration;

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
    public ActionResult<IEnumerable<ProductDto>> Create([FromBody] ProductsCreationDto productsCreationDto)
    {
        try
        {
            Response.StatusCode = 201;
            return _inventoryService.CreateProducts(productsCreationDto.Products, productsCreationDto.UserId).ToList();
        }
        catch (InvalidUserException message)
        {
            return BadRequest(message);
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductResultDto>> Get(int? userId)
    {
        try
        {
            Response.StatusCode = 400;
            if (userId != null) return _inventoryService.Get((int)userId).ToList();

            throw new InvalidUserException();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    //[HttpGet]
    //public IEnumerable<Product> Get()
    //{
    //    var inventoryItems = new List<Product>();
    //    var profile = new Integration
    //    {
    //        Id = 1,
    //        WooIntegration = new WooIntegration
    //        {
    //            Id = 1,
    //            WooConsumerKey = "ck_0c436b3a21352f0298a30a683dc020fe4deed527",
    //            WooConsumerSecret = "cs_090854fa655720b1ec5318861fde1e400eec8c27",
    //            WooUrl = "https://benparr.tech/blog/"
    //        }
    //    };
    //    _inventoryService.AddInventoryItems(inventoryItems, profile);
    //    return inventoryItems;
    //}

    [HttpPatch]
    public Product Update()
    {
        throw new NotImplementedException();
    }
}