namespace RentCars.Types;

// O enum deve conter o campo Confirmed com valor 0
// O enum deve conter o campo Finished com valor 1
// O enum deve conter o campo Cancelled com valor igual ao Finished
public enum RentStatus
{

    Confirmed = 0,

    Finished = 1,

    Cancelled = Finished

}
