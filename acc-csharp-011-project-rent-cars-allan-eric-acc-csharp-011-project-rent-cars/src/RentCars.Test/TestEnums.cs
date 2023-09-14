using FluentAssertions;
using RentCars.Types;

namespace RentCars.Test;

public class TestEnums
{
    [Theory]
    [InlineData(1, "Chamber")]
    [InlineData(2, "Disc")]
    [InlineData(3, "Drum")]
    public void BreakeTypeShouldHaveCorrectValues(int valueEntry, string expected)
    {
        RentCars.Models.Truck truck = new();
        truck.BrakeType = (BrakeType)valueEntry;
        truck.BrakeType.ToString().Should().Be(expected);

    }

    [Theory]
    [InlineData(0, "FrontWheelDrive")]
    [InlineData(1, "RearWheelDrive")]
    [InlineData(2, "AllWheelDrive")]
    public void TractionTypeShouldHaveCorrectValues(int valueEntry, string expected)
    {
        RentCars.Models.Car car = new();
        car.Traction = (TractionType)valueEntry;
        car.Traction.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(10, "Alcohol")]
    [InlineData(20, "Gasoline")]
    [InlineData(30, "Flex")]
    [InlineData(40, "Diesel")]
    [InlineData(50, "Electric")]
    [InlineData(60, "Hybrid")]
    public void FuelTypeShouldHaveCorrectValues(int valueEntry, string expected)
    {
        RentCars.Models.Car car = new();
        car.Fuel = (FuelType)valueEntry;
        car.Fuel.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(0, "Confirmed")]
    [InlineData(1, "Finished")]
    public void RentStatusShouldHaveCorrectValues(int valueEntry, string expected)
    {
        var rentStatus = (RentStatus)valueEntry;
        rentStatus.ToString().Should().Be(expected);

    }

    [Fact]
    public void RentStatusFinishedShouldBeTheSameValueAsCancelled()
    {
        var rentStatusFinished = RentStatus.Finished;
        var rentStatusCancelled = RentStatus.Cancelled;
        rentStatusFinished.Should().Be(rentStatusCancelled);

    }
}
