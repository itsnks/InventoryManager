using InventoryManager.Data;
using InventoryManager.Models;
using InventoryManager.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public ItemsController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var allItems = _db.Items.ToList();
            return Ok(allItems);
        }

        [HttpPost]
        public IActionResult AddItems(AddItemsDTO addItemsDTO)
        {
            var itemEntity = new Item()
            {
                Id = addItemsDTO.Id,
                ItemName = addItemsDTO.ItemName,
                ItemQuantity = addItemsDTO.ItemQuantity,
                ItemRate = addItemsDTO.ItemRate
            };

            if (ModelState.IsValid)
            {
                _db.Items.Add(itemEntity);
                _db.SaveChanges();
            }

            return Ok(itemEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateItems(int id,UpdateItemDTO updateItemDTO)
        {
            Item item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.ItemName = updateItemDTO.ItemName;
            item.ItemQuantity = updateItemDTO.ItemQuantity;
            item.ItemRate = updateItemDTO.ItemRate;

            _db.Items.Update(item);
            _db.SaveChanges();

            return Ok(item);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var entity = _db.Items.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            _db.Items.Remove(entity);
            _db.SaveChanges();
            return Ok();
        }
    }
}
