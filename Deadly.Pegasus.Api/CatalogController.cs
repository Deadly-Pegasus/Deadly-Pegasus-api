using Microsoft.AspNetCore.Mvc;
using Deadly.Pegasus.Domain.Catalog;

namespace Deadly.Pegasus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
       [HttpGet]
        public IActionResult GetItems()
        {
            return Ok("hello world.");
        }
    }
}