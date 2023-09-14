using BookingApi.Repository;
using FluentAssertions;

namespace BookingApi.Test;

public class RepositoryTest
{
    [Theory(DisplayName = "MakeReservation deve criar e retornar um novo booking")]
    [MemberData(nameof(MakeReservation_ShouldCreateReservationData))]
    public void MakeReservation_ShouldCreateReservation(BookingContext context, int hotelId, int userId)
    {
        var repository = new BookingRepository(context);
        var res = repository.MakeReservation(hotelId, userId, DateTime.Now, DateTime.Now.AddDays(5));
        res.Should().NotBeNull();
        res.UserId.Should().Be(userId);
        res.HotelId.Should().Be(hotelId);
    }
    public readonly static TheoryData<BookingContext, int, int> MakeReservation_ShouldCreateReservationData =
    new()
    {
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldCreateReservation"),
            1,
            1
        },
    };


    [Theory(DisplayName = "MakeReservation deve lançar exceção quando o hotel não tiver quartos disponíveis ou quando usuário ou hotel não existir")]
    [MemberData(nameof(MakeReservation_ShouldThrowInvalidOperationData))]
    public void MakeReservation_ShouldThrowInvalidOperation(BookingContext context, int hotelId, int userId)
    {
        var repository = new BookingRepository(context);
        Action act = () => repository.MakeReservation(hotelId, userId, DateTime.Now, DateTime.Now.AddDays(5));
        act.Should().Throw<InvalidOperationException>();

    }
    public readonly static TheoryData<BookingContext, int, int> MakeReservation_ShouldThrowInvalidOperationData =
    new()
    {
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldThrowInvalidOperation1"),
            50, // hotel não existe
            50 // usuário não existe
        },
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldThrowInvalidOperation2"),
            3,
            1
        },
    };

}