namespace Geometry;
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Area { get => Width * Height; }
    public double Perimeter { get => 2 * (Width + Height); }

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("Width and height must be positive");
        }
        Width = width;
        Height = height;
    }
}