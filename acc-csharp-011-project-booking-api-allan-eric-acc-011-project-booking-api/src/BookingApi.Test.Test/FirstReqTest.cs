using Microsoft.EntityFrameworkCore;
using BookingApi.Repository;
using BookingApi.Models;
using FluentAssertions;

namespace BookingApi.Test.Test;

public class FirstReqTest
{
    [Trait("Category", "1 - Finalizar a implementação do repositório")]
    [Theory(DisplayName = "Implemente o teste MakeReservation_ShouldCreateReservation")]
    [MemberData(nameof(MakeReservation_ShouldCreateReservationData))]
    public void TestMakeReservation_ShouldCreateReservation(BookingContext context, int hotelId, int userId, bool isCorrect)
    {
        var instance = new RepositoryTest();
        Action act = () => instance.MakeReservation_ShouldCreateReservation(context, hotelId, userId);
        if (isCorrect)
        {
            act.Should().NotThrow();
        }
        else
        {
            try {
                act();
            }
            catch (Exception e)
            {
                e.Should().Match(
                    ex => ex.GetType() == typeof(InvalidOperationException) || ex.GetType() == typeof(Xunit.Sdk.XunitException)
                );
            }
        }

        act.Should().NotThrow<NotImplementedException>();
    }
    public readonly static TheoryData<BookingContext, int, int, bool> MakeReservation_ShouldCreateReservationData =
    new()
    {
        {
            Helpers.GetContextInstanceForTests("TestMakeReservation_ShouldCreateReservation1"),
            1,
            1,
            true
        },
        {
            Helpers.GetContextInstanceForTests("TestMakeReservation_ShouldCreateReservation2"),
            50,
            50,
            false
        },
        {
            Helpers.GetContextInstanceForTests("TestMakeReservation_ShouldCreateReservation3"),
            3,
            1,
            false
        },
    };
    

    [Trait("Category", "1 - Finalizar a implementação repositório")]
    [Theory(DisplayName = "Implemente o teste MakeReservation_ShouldThrowInvalidOperation")]
    [MemberData(nameof(MakeReservation_ShouldThrowInvalidOperationData))]
    public void TestMakeReservation_ShouldThrowInvalidOperation(BookingContext context, int hotelId, int userId, bool isCorrect)
    {
        var instance = new RepositoryTest();
        Action act = () => instance.MakeReservation_ShouldThrowInvalidOperation(context, hotelId, userId);
        if (isCorrect)
        {
            act.Should().NotThrow();
        }
        else
        {
            try {
                act();
            }
            catch (Exception e)
            {
                e.Should().Match(
                    ex => ex.GetType() == typeof(InvalidOperationException) || ex.GetType() == typeof(Xunit.Sdk.XunitException)
                );
            }
        }

        act.Should().NotThrow<NotImplementedException>();
    }
    public readonly static TheoryData<BookingContext, int, int, bool> MakeReservation_ShouldThrowInvalidOperationData =
    new()
    {
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldThrowInvalidOperation1"),
            50,
            50,
            true
        },
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldThrowInvalidOperation2"),
            3,
            1,
            true
        },
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldThrowInvalidOperation3"),
            1,
            1,
            false
        },
        {
            Helpers.GetContextInstanceForTests("MakeReservation_ShouldThrowInvalidOperation4"),
            2,
            2,
            false
        }
    };
}
