using System.Globalization;
namespace calendar_events;
//  ok

// Complete a classe Event, localizada em src/calendar-events/IEvent.cs, para que ela implemente a interface IEvent.

// A classe Event deve ter dois construtores.

// Um com os seguintes campos: string title, string date e string description.

// E o outro com apenas string title, string date.

// A data deve ser convertida de string para o tipo DateTime

public class Event : IEvent
{
    public string? Title {get; set; }
    public DateTime EventDate {get; set; }
    public string? Description {get; set; }
        

    public Event(string title, string date, string description)
    {
    
        Title = title;
        EventDate = DateTime.Parse(date);
        Description = description;
    
    }

    public Event(string title, string date)
    {
        Title = title;
        EventDate = DateTime.Parse(date); 
    }

// A função deve receber um número de dias de formato inteiro e atrasar a data do evento com essa quantidade de dias.
    public void DelayDate(int days)
    {
        EventDate = EventDate.AddDays(days);
    }

// A função deve receber por parâmetro o formato de impressão do evento, e as entradas serão "detailed" ou "normal".

// Se for passada a string "normal", a função deve retornar um relatório em formato string conforme o seguinte:
// "Evento = Date = <DATA DO EVENTO NO FORMATO "d">

// "

// Se for passada a string "detailed", a função deve retornar um relatório em formato string conforme o seguinte:
// "Evento = Date = <DATA DO EVENTO NO FORMATO "d"> Description = <DESCRIÇÃO DO EVENTO> "
    public string PrintEvent(string format)
    {
        if (format == "normal")
        {
            return $"Evento = {Title}\nDate = {EventDate:d}\n";
        }
        else if (format == "detailed")
        {
            return $"Evento = {Title}\nDate = {EventDate:d}\nDescription = {Description}";
        }
        else
        {
            return "Formato inválido";
        }   
    }
}
