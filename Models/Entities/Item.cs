namespace InventoryManager.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public float ItemQuantity { get; set; }
        public float ItemRate { get; set; }
    }
}
