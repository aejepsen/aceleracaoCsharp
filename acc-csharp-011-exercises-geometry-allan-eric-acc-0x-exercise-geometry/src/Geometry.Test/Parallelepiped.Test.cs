namespace Geometry.Test;

public class ParallelepipedTest
{
    [InlineData(2, 3, 4)]
    [InlineData(3, 4, 5)]
    [Theory]
    public void TestParallelepiped(double height, double width, double depth)
    {
        Parallelepiped p = new Parallelepiped(height, width, depth);
        p.Height.Should().Be(height);
        p.Width.Should().Be(width);
        p.Depth.Should().Be(depth);
        p.Volume.Should().Be(height * width * depth);
        p.SurfaceArea.Should().Be(2 * (height * width + height * depth + width * depth));
        p.FaceA.GetType().IsInstanceOfType(typeof(Rectangle));
        p.FaceB.GetType().IsInstanceOfType(typeof(Rectangle));
        p.FaceC.GetType().IsInstanceOfType(typeof(Rectangle));
        p.FaceA.Area.Should().Be(height * width);
        p.FaceB.Area.Should().Be(height * depth);
        p.FaceC.Area.Should().Be(width * depth);
    }
    [InlineData(-2, 3, 4)]
    [InlineData(3, 4, 0)]
    [Theory]
    public void TestParallelepipedException(double height, double width, double depth){

        Action act = () => new Parallelepiped(height, width, depth);
        act.Should().Throw<ArgumentException>().WithMessage("Dimensions must be positive and non-zero");    
    }
}