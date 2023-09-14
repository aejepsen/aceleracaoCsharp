using Xunit;
using FluentAssertions;
using System;
using TrybeLibrary;
using LibraryTypes;

namespace TrybeLibrary.Test;

public class TestBookType
{
    [Trait("Category", "2 - Crie a struct Book")]
    [Fact(DisplayName = "Deve ter criado corretamente a struct Book")]    
    public void TestBookExists()
    {
        Book book = new();
        book.Should().NotBeNull();
        Action act = () => book.BookType = BookTypes.Fiction;
        act.Should().NotThrow<NotImplementedException>();

    }

    [Trait("Category", "2 - Crie a struct Book")]
    [Fact(DisplayName = "Deve ter criado corretamente a struct Book")]    
    public void TestBookTypeExists()
    {
        Book book = new();
        book.Should().NotBeNull();
        Action act = () => book.BookType = BookTypes.Fiction;
        act.Should().NotThrow<NotImplementedException>();
    }
}
