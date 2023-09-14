using RentCars.Types;

namespace RentCars.Models;

// O construtor deve receber uma instância de Vehicle, uma de Person e um valor inteiro com os dias alugados.

// Para calcular o atributo Price deve-se seguir a seguinte regra:

// Para pessoas fisícas o preço deve ser o preço por dia do veículo * os dias alugados.
// Para pessoas jurídicas o preço deve ser o preço por dia do veículo * os dias alugados com 10% de desconto.
// O status inicial deve ser RentStatus.Confirmed.

// O construtor deve alterar o atributo IsRented do veículo para true. O construtor deve alterar o atributo Debit da pessoa para o Preço calculado.

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;
        Vehicle.IsRented = true;
        if (person is PhysicalPerson)
        // if(person.GetType() == typeof(PhysicalPerson))
        {
            Status = RentStatus.Confirmed;
            Price = vehicle.PricePerDay * daysRented;
            person.Debit = Price;
        }
        else
        {
            Price = vehicle.PricePerDay * daysRented * 0.9;
            Status = RentStatus.Confirmed;
            person.Debit = Price;
        }
    }

  public void Cancel()
    {        
        Status = RentStatus.Cancelled;
    }

    public void Finish()
    {        
        Status = RentStatus.Finished;
    }
}
