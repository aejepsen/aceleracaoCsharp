using pokedex;

namespace pokedex.API_Requests;

public class PokemonRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public string[]? Types { get; set;}
}