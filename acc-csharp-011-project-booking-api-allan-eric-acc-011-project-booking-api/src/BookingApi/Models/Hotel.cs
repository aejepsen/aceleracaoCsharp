using System.Text.Json.Serialization;

namespace BookingApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int NumberAvailableRooms { get; set; }
        public int TotalRooms { get; set; }
        
        [JsonIgnore]
        public ICollection<Booking>? Bookings { get; set; }
    }
}