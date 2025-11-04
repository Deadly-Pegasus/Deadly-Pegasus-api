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
            //var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            //item.Id = id;

            //return Ok(item);

            //return Ok(_db.Items.Find(id));

            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost] 
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
            //return Created("/catalog/42", item);
        } 

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating (int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.AddRating(rating);
            _db.SaveChanges();
            return Ok(item);
            //var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            //item.Id = id;
            //item.AddRating(rating);

            //return Ok(item);
        }

        [HttpPut("{id:int}")]
        //public IActionResult Put(int id, Item item)
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }

            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges(); 
            
            return Ok();
            //return NoContent();
        }
    } // FIXED: closes class after Post
} // FIXED: closes namespace after class

