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
        public IActionResult GetItems()
        {
            var allItems = _db.Items.ToString();
            return Ok();
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
    }
}
