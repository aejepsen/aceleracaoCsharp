using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFourthReq
{
    [Theory(DisplayName = "Deve transefir um valor com uma conta logada")]
    [InlineData(1000, 500)]
    public void TestTransferSucess(int balance, int value)
    {        
        Trybank bank = new();
        var newBalance = balance - value;
        bank.RegisterAccount(123, 123, 123);
        bank.RegisterAccount(124, 124, 124);
        bank.Login(123, 123, 123);
        bank.CheckBalance().Should().Be(balance);
        bank.Deposit(balance);
        bank.Transfer(124, 124, value);
        bank.CheckBalance().Should().Be(newBalance);

    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestTransferWithoutLogin(int value)
    {        
        Trybank bank = new();
        Action act = () => bank.Transfer(1, 2, value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0, 100)]
    public void TestTransferWithoutBalance(int balance, int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(123, 123, 123);
        bank.RegisterAccount(124, 124, 124);
        bank.Login(123, 123, 123);
        bank.Deposit(balance);
        Action act = () => bank.Transfer(124, 124, value);
        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}
