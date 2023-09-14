namespace Geometry.Test;

public class CubeTest
{
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [Theory]
    public void TestCube(double side)
    {
        Cube c = new Cube(side);
        c.Side.Should().Be(side);
        c.Height.Should().Be(side);
        c.Width.Should().Be(side);
        c.Depth.Should().Be(side);
        c.Volume.Should().Be(Math.Pow(side, 3));
        c.SurfaceArea.Should().Be(6 * Math.Pow(side, 2));
        c.FaceA.GetType().IsInstanceOfType(typeof(Parallelepiped));
        c.FaceB.GetType().IsInstanceOfType(typeof(Parallelepiped));
        c.FaceC.GetType().IsInstanceOfType(typeof(Parallelepiped));
        c.FaceA.Area.Should().Be(Math.Pow(side, 2));
        c.FaceB.Area.Should().Be(Math.Pow(side, 2));
        c.FaceC.Area.Should().Be(Math.Pow(side, 2));
    }
    
    [InlineData(-2)]
    [InlineData(0)]
    [Theory]
    public void TestCubeException(double side){
        Action act = () => new Cube(side);
        act.Should().Throw<ArgumentException>();}
}