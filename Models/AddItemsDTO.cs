namespace InventoryManager.Models
{
    public class AddItemsDTO
    {
        public int Id { get; set; }
        public required string ItemName { get; set; }
        public required float ItemQuantity { get; set; }
        public required float ItemRate { get; set; }
    }
}
