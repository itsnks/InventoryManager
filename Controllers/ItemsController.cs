using InventoryManager.Data;
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
    }
}
