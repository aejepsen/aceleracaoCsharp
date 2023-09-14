namespace EShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? Description  { get; set; }

        public string? Product { get; set; }

        public int ClientIdentity { get; set; }

        public Client? Client { get; set; }
    }
}
