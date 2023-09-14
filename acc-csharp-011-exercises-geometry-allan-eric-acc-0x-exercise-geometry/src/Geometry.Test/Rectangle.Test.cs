namespace Geometry.Test;

public class RectangleTest
{
    [InlineData(2, 2)]
    [InlineData(10, 5)]
    [Theory]
    public void TestRectangle(double sideA, double sideB)
    {
        Rectangle rectangle = new(sideA, sideB);
        rectangle.Width.Should().Be(sideA);
        rectangle.Height.Should().Be(sideB);
        rectangle.Area.Should().Be(sideA * sideB);
        rectangle.Perimeter.Should().Be(2 * (sideA + sideB));
        
    }

    [InlineData(0, 4)]
    [InlineData(4, 0)]
    [InlineData(4, -1)]
    [InlineData(-1, 4)]
    [Theory]
    public void TestRectangleNonPositiveSideException(double sideA, double sideB)
    {
        Action action = () => new Rectangle(sideA, sideB);
        action.Should().Throw<ArgumentException>().WithMessage("Width and height must be positive");
    }
}