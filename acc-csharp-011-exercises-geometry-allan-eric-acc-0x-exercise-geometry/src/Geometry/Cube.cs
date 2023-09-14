namespace Geometry;

public class Cube : Parallelepiped

{

    public double Side;

    public Cube(double side) : base(side, side, side)
    {
        Side = side;

    }

    // Por fim, sobrescreva as propriedades FaceA, FaceB e FaceC da classe base para que o tipo retornado pelas três seja um Square, e não um Rectangle

    public new Square FaceA => new Square(Side);

    public new Square FaceB => new Square(Side);

    public new Square FaceC => new Square(Side);

}