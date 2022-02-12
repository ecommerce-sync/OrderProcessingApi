using Microsoft.AspNetCore.Mvc;

namespace OrderProcessingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryInitializerController : ControllerBase
    {

        // POST <InitialiserController>
        /// <summary>
        /// Performs the initial upload from the specified platform
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="platform"></param>
        [HttpPost]
        public void Post(int userId, string platform)
        {
            //Fetch products from platform
            //Add products to database
        }
    }
}
