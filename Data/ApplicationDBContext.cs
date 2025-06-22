using InventoryManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
