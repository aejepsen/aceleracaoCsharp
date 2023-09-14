namespace code_first.Models
{
    /*
    Product deve conter as seguintes propriedades:

Uma chave primária.
Uma propriedade de navegação para Category de nome Category.
Uma propriedade Name do tipo string.
Uma chave estrangeira para Category de nome CategoryId. */

    public sealed class Product
    {
        public int ProductId {get; set;}
        public string? Name {get; set;}

        public int CategoryId {get; set;}

        public Category? Category {get; set;}


    }
}
