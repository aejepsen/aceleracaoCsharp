namespace BookingApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
