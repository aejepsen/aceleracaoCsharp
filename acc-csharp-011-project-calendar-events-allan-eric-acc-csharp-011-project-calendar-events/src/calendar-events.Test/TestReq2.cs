using Xunit;
using FluentAssertions;
using calendar_events;
using System;

namespace calendar_events.Test;

public class TestReq2
{
    [Theory(DisplayName = "Deve procurar um evento por titulo")]
    [InlineData("Festa do bolo", "01/01/2023", "no supermercado", 0)]
    public void TestListSearchByTitle(string title, string date, string description,int expected)
    {
        var el = new EventList();
        el.Add(new Event(title, date, description));
        var result = el.SearchByTitle(title);
        result.Should().Be(expected);
        
    }

    [Theory(DisplayName = "Deve procurar um evento por data")]
    [InlineData("comprar arroz", "01/01/2023", "no supermercado", 0)]
    public void TestListSearchByDate(string title, string date, string description, int expected)
    {
        EventList el = new EventList();
        el.Add(new Event(title, date, description));

        el.SearchByDate(date).Should().Be(expected);
        // el.SearchByDate(DateTime.Parse("2021-01-01")).Should().Be(-1);
    }

    
}