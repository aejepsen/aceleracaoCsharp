namespace Geometry;
public class Parallelepiped
{
  public double Height { get; }

  public double Width { get; }

  public double Depth { get; }

  public double Volume { get => Height * Width * Depth; }

  public Rectangle FaceA { get; }

  public Rectangle FaceB { get; }

  public Rectangle FaceC { get; }

  public double SurfaceArea { get => 2 * (FaceA.Area + FaceB.Area + FaceC.Area);}

  public Parallelepiped(double height, double width, double depth)
  {
   if (height <= 0 || width <= 0 || depth <= 0)
   {
    throw new ArgumentException("Dimensions must be positive and non-zero");
   }
    Height = height;
    Width = width;
    Depth = depth;
    FaceA = new Rectangle(Height, Width);
    FaceB = new Rectangle(Height, Depth);
    FaceC = new Rectangle(Width, Depth);
  }
}
