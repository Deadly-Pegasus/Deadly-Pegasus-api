using Microsoft.AspNetCore.Mvc;
using Deadly.Pegasus.Domain.Catalog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Deadly.Pegasus.Data;

namespace Deadly.Pegasus.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);
        }

        [HttpPost] // FIXED: moved inside the class
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        } // FIXED: properly placed inside the class

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating (int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    } // FIXED: closes class after Post
} // FIXED: closes namespace after class

