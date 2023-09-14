namespace Geometry.Test;

public class SquareTest
{
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [Theory]
    public void TestSquare(double side)
    {
        Square square = new(side);
        square.GetType().IsInstanceOfType(typeof(Rectangle));
        square.Width.Should().Be(side);
        square.Height.Should().Be(side);
        square.Area.Should().Be(side * side);
        square.Perimeter.Should().Be(4 * side);
    }
    [InlineData(-2)]
    [InlineData(0)]
    [Theory]
    public void TestSquareException(double side)
    {
        Action action = () => new Square(side);
        action.Should().Throw<ArgumentException>();
    }
}