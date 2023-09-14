using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestSecondReq
{
    [Theory(DisplayName = "Deve logar em uma conta!")]
    [InlineData(1, 2, 3)]
    public void TestLoginSucess(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        tryBank.RegisterAccount(number, agency, pass);
        tryBank.Login(number, agency, pass);
        tryBank.Logged.Should().BeTrue();
        tryBank.loggedUser.Should().NotBe(-99);

    }

    [Theory(DisplayName = "Deve retornar exceção ao tentar logar em conta já logada")]
    [InlineData(1, 2, 3)]
    public void TestLoginExceptionLogged(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        tryBank.RegisterAccount(number, agency, pass);
        tryBank.Login(number, agency, pass);
        Action action = () => tryBank.Login(number, agency, pass);
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve retornar exceção ao errar a senha")]
    [InlineData(1, 2, 3)]
    public void TestLoginExceptionWrongPass(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        tryBank.RegisterAccount(number, agency, pass);
        Action action = () => tryBank.Login(number, agency, 4);
        action.Should().Throw<ArgumentException>().WithMessage("Senha incorreta");
    }

    [Theory(DisplayName = "Deve retornar exceção ao digitar conta que não existe")]
    [InlineData(1, 2, 3)]
    public void TestLoginExceptionNotFounded(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        Action action = () => tryBank.Login(number, agency, pass);
        action.Should().Throw<ArgumentException>().WithMessage("Agência + Conta não encontrada");
    }

    [Theory(DisplayName = "Deve sair de uma conta!")]
    [InlineData(1, 2, 3)]
    public void TestLogoutSucess(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        tryBank.RegisterAccount(number, agency, pass);
        tryBank.Login(number, agency, pass);
        tryBank.Logged.Should().BeTrue();
        tryBank.loggedUser.Should().NotBe(-99);
        tryBank.Logout();
        tryBank.Logged.Should().BeFalse();
        tryBank.loggedUser.Should().Be(-99);
    }

    [Theory(DisplayName = "Deve retornar exceção ao sair quando não está logado")]
    [InlineData(1, 2, 3)]
    public void TestLogoutExceptionNotLogged(int number, int agency, int pass)
    {        
        Trybank tryBank = new();
        Action action = () => tryBank.Logout();
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

}
