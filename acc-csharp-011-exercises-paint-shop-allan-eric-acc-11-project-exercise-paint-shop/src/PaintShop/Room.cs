namespace PaintShop;


// A classe Room não deve ser estática
// A classe Room deve possuir uma propriedade pública Walls que seja um array de objetos do tipo Wall que criamos no requisito 2 (ou seja, um Wall[]). Essa propriedade não deve possuir um set.
// A classe Room deve possuir uma propriedade pública TotalPaintableArea do tipo double que represente toda a superfície a ser pintada
// A classe Room deve possuir um construtor que receba um Wall[] e o atribua à propriedade Walls

// Ao criar um cômodo, iremos passar as de paredes que o irão compor e, a partir dessa informação, poderemos retornar o total da área a ser pintada para usar na classe de utilidades que criaremos a seguir.

public class Room
{
    public Wall[] Walls { get; }
    public double TotalPaintableArea { get;}

    public Room(params Wall[] walls)
    {
        Walls = walls;
        TotalPaintableArea = 0;
        foreach (var wall in walls)
        {
            TotalPaintableArea += wall.PaintableArea;
        }
    }
}