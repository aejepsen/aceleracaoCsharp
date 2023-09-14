using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestThirdReq
{
    [Theory(DisplayName = "Deve devolver o saldo em uma conta logada")]
    [InlineData(0)]
    public void TestCheckBalanceSucess(int balance)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1,2,3);
        bank.Login(1,2,3);
        bank.Deposit(balance);
        bank.CheckBalance().Should().Be(balance);

    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestCheckBalanceWithoutLogin(int balance)
    {        
        Trybank bank = new();
        Action act = () => bank.CheckBalance();
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve depositar um saldo em uma conta logada")]
    [InlineData(0)]
    [InlineData(10)]
    public void TestDepositSucess(int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1,2,3);
        bank.Login(1,2,3);
        bank.Deposit(value);
        bank.CheckBalance().Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestDepositWithoutLogin(int value)
    {        
        Trybank bank = new();
        Action act = () => bank.Deposit(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve sacar um valor em uma conta logada")]
    [InlineData(0, 0)]
    public void TestWithdrawSucess(int balance, int value)
    {        
        Trybank bank = new();
        var newBalance = balance - value;
        bank.RegisterAccount(1,2,3);
        bank.Login(1,2,3);
        bank.Deposit(balance);
        bank.Withdraw(value);
        bank.CheckBalance().Should().Be(newBalance);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestWithdrawWithoutLogin(int value)
    {        
        Trybank bank = new();
        Action act = () => bank.Withdraw(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0, 0)]
    public void TestWithdrawWithoutBalance(int balance, int value)
    {        
        Trybank bank = new();
        Action act = () => bank.Withdraw(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");

    }
}