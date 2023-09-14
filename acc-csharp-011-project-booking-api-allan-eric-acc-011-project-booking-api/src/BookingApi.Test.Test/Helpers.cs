using Microsoft.EntityFrameworkCore;
using BookingApi.Models;
using BookingApi.Repository;

namespace BookingApi.Test.Test
{
    public static class Helpers
    {
        public static BookingContext GetContextInstanceForTests(string inMemoryDbName)
        {
            var contextOptions = new DbContextOptionsBuilder<BookingContext>()
                .UseInMemoryDatabase(inMemoryDbName)
                .Options;
            var context = new BookingContext(contextOptions);
            context.Hotels.AddRange(
                GetHotelListForTests()
            );
            context.SaveChanges();
            context.Users.AddRange(
                GetUserListForTests()
            );
            context.SaveChanges();
            context.Bookings.AddRange(
                GetBookingListForTests()
            );
            context.SaveChanges();
            return context;
        }

        public static List<Hotel> GetHotelListForTests() => 
        new() {
            new Hotel {
                Id = 1,
                Name = "Hotel BH",
                City = "Belo Horizonte",
                Country = "Brasil",
                NumberAvailableRooms = 5,
                TotalRooms = 10
            },
            new Hotel {
                Id = 2,
                Name = "Hotel Salvador",
                City = "Salvador",
                Country = "Brasil",
                NumberAvailableRooms = 5,
                TotalRooms = 5
            },
            new Hotel {
                Id = 3,
                Name = "Hotel SP",
                City = "São Paulo",
                Country = "Brasil",
                NumberAvailableRooms = 0,
                TotalRooms = 10
            },
        };

        public static List<User> GetUserListForTests() =>
        new() {
            new User {
                Id = 1,
                Name = "Pessoa Usuária 1",
                Email = "pessoa.usuaria.1@tryber.com",
                Password = "123456"
            },
            new User {
                Id = 2,
                Name = "Pessoa Usuária 2",
                Email = "pessoa.usuaria.2@tryber.com",
                Password = "123456"
            },
            new User {
                Id = 3,
                Name = "Pessoa Usuária 3",
                Email = "pessoa.usuaria.3@tryber.com",
                Password = "123456"
            },
        };

        public static List<Booking> GetBookingListForTests() =>
        new() {
            new Booking {
                Id = 1,
                UserId = 1,
                HotelId = 1,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(1)
            },
            new Booking {
                Id = 2,
                UserId = 2,
                HotelId = 2,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(5)
            }
        };
    }
}