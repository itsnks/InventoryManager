namespace InventoryManager.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public required string ItemName { get; set; }
        public required float ItemQuantity { get; set; }
        public required float ItemRate { get; set; }
    }
}
