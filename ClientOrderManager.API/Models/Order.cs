namespace ClientOrderManager.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}