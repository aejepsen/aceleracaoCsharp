using Xunit;
using FluentAssertions;
using System;
using TrybeLibrary;
using LibraryTypes;

namespace TrybeLibrary.Test;

public class TestBook
{
    [Trait("Category", "1 - Crie o enum BookTypes")]
    [Fact(DisplayName = "Deve ter criado corretamente o enum BookTypes")]    
    public void TestBookTypesExists()
    {
        LibraryTypes.BookTypes bookType = new();
        bookType.Should().NotBe(null);
    }

    [Trait("Category", "1 - Crie o enum BookTypes")]
    [Theory(DisplayName = "BookType deve conter 6 tipos de livros")]
    [InlineData(0, "Fiction")]
    [InlineData(1, "NonFiction")]
    [InlineData(2, "Children")]
    [InlineData(3, "Science")]
    [InlineData(4, "Technology")]
    [InlineData(5, "Romance")]
    public void TestBookTypesCount(int type, string name)
    {
        BookTypes bookType = (LibraryTypes.BookTypes)type;
        Book book = new(bookType);
        bookType.ToString().Should().Be(name);
    }
}