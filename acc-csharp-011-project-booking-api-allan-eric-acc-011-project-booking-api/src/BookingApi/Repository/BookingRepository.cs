using BookingApi.Models;

namespace BookingApi.Repository
{
    public class BookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        public void AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public Hotel? GetHotel(int id)
        {
            return _context.Hotels.Find(id);
        }

        public User? GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public Booking? GetBooking(int id)
        {
            return _context.Bookings.Find(id);
        }

        public IEnumerable<Hotel> GetHotels()
        {
            return _context.Hotels.ToList();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        public void UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public Booking MakeReservation(int hotelId, int userId, DateTime checkin, DateTime checkout)
        {
            if (GetUser(userId) == null || GetHotel(hotelId) == null) throw new InvalidOperationException("Hotel or user not found");
            else if (GetHotel(hotelId).NumberAvailableRooms == 0) throw new InvalidOperationException("No rooms available");
            var newBooking = new Booking() { UserId = userId, HotelId = hotelId, CheckIn = checkin, CheckOut = checkout };
            AddBooking(newBooking);
            var bookingCreated = _context.Bookings.First(x => x == newBooking);
            return bookingCreated;

        }

        public void RemoveHotel(Hotel hotel)
        {
            var hotelInDb = _context.Hotels.Find(hotel.Id);
            if (hotelInDb != null)
            {
                var onGoingBookings =
                    from booking in _context.Bookings
                    where booking.Hotel.Id == hotel.Id
                    where booking.CheckOut > DateTime.Now
                    select booking;
                if (!onGoingBookings.Any())
                {
                    _context.Hotels.Remove(hotelInDb);
                    _context.SaveChanges();
                    return;
                }
                throw new InvalidOperationException("Hotel has on-going bookings");
            }
        }

        public void RemoveUser(User user)
        {
            var userInDb = _context.Users.Find(user.Id);
            if (userInDb != null)
            {
                var onGoingBookings =
                    from booking in _context.Bookings
                    where booking.User.Id == user.Id
                    where booking.CheckOut > DateTime.Now
                    select booking;
                if (!onGoingBookings.Any())
                {
                    _context.Users.Remove(userInDb);
                    _context.SaveChanges();
                    return;
                }
                throw new InvalidOperationException("User has on-going bookings");
            }
        }

        public void RemoveBooking(Booking booking)
        {
            var bookingInDb = _context.Bookings.Find(booking.Id);
            if (bookingInDb != null)
            {
                if (bookingInDb.CheckIn < DateTime.Now)
                {
                    throw new InvalidOperationException("Booking has already been made");
                }
                _context.Bookings.Remove(bookingInDb);
                _context.SaveChanges();
            }
        }
    }
}
