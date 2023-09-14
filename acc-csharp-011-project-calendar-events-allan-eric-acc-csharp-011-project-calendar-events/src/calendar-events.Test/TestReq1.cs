using Xunit;
using FluentAssertions;
using calendar_events;
using System;

namespace calendar_events.Test;

public class TestReq1
{
    [Theory(DisplayName = "Deve cadastrar um evento com o construtor completo")]
    [InlineData("comprar arroz", "01/01/2023", "no supermercado")]
    public void TestEventFullConstructor(string title, string date, string description)
    {
        Event e = new Event(title, date, description);

        e.Title.Should().Be(title);

        e.EventDate.Should().Be(DateTime.Parse(date));

        e.Description.Should().Be(description);
    }

    [Theory(DisplayName = "Deve cadastrar um evento com o construtor sem descrição")]
    [InlineData("comprar arroz", "01/01/2023")]
    public void TestEventHalfConstructor(string title, string date)
    {
        Event e = new Event(title, date);

        e.Title.Should().Be(title);

        e.EventDate.Should().Be(DateTime.Parse(date));

        e.Description.Should().Be(null);

    }

    [Theory(DisplayName = "Deve atrasar a data de um evento corretamente")]
    [InlineData("comprar arroz", "01/01/2023", 10, "11/01/2023")]
    public void TestEventDelayDate(string title, string date, int days, string expected)
    {
        Event e = new Event(title, date);

        e.DelayDate(days);

        e.EventDate.Should().Be(DateTime.Parse(expected));
        
    }

    [Theory(DisplayName = "Deve imprimir um evento corretamente")]
    [InlineData("comprar arroz", "01/01/2023", "no supermercado", "detailed", "Evento = comprar arroz\nDate: 01/01/2023\nDescrição = no supermercado")]
    [InlineData("comprar arroz", "01/01/2023", "no supermercado", "normal", "Evento = comprar arroz\nDate = 01/01/2023\n")]    
    public void TestPrintEvent(string title, string date, string description, string format, string expected)
    {
        Event e = new Event(title, date, description);

        e.PrintEvent(format).Should().Be(expected);
    }
    
    
}