namespace EShop.Models
// ok
/* Defina a chave primária de Client utilizando FluentAPI

Você deve definir a chave primária do model Client que se encontra em src/Models/Client.cs.

A chave deve ser um inteiro com o nome ClientIdentity.*/
{
    public class Client
    {
        public int ClientIdentity { get; set; }
        public string Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
