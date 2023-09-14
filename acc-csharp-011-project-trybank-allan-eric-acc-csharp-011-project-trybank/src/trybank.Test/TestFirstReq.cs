using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFirstReq
{
    [Theory(DisplayName = "Deve cadastrar contas com sucesso!")]
    [InlineData(1234, 123, 1010)]
    [InlineData(1111, 123, 0123)]
    [InlineData(0001, 123, 0000)]
    [InlineData(9999999, 123, 9999)]
    [InlineData(1, 2, 3)]
    public void TestRegisterAccountSucess(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        int registeredAccounts = tryBank.registeredAccounts;
        tryBank.RegisterAccount(number, agency, pass);
        int[] Params = {number, agency, pass};
        foreach (int param in Params)
        {
            tryBank.Bank[registeredAccounts, Array.IndexOf(Params, param)].Should().Be(param);
        } 
        
    }

    [Theory(DisplayName = "Deve retornar ArgumentException ao cadastrar contas que já existem")]
    [InlineData(120, 550, 0)]
    public void TestRegisterAccountException(int number, int agency, int pass)
    {        
        
        Trybank tryBank = new();
        tryBank.RegisterAccount(number, agency, pass);
        Action action = () => tryBank.RegisterAccount(number, agency, pass);
        action.Should().Throw<ArgumentException>().WithMessage("A conta já está sendo usada!");
    }
}