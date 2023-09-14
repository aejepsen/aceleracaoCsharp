using FluentAssertions;
using Xunit;

namespace SelectionProcessValidation.Test;

public class TestSelectionProcessValidation
{
    [Theory(DisplayName = "Teste de sucesso para validação de processo de seleção")]
    [InlineData("Maria;João;Fernanda;Felipe;Maurício;Mayara", "Maria", true)]
    public void TestSelectionProcessValidationSuccess(string selectedPeople, string name, bool resultExpected)
    {
        var validateName = new SelectionProcessValidation().ValidateName(selectedPeople, name);
        validateName.Should().Be(resultExpected);
    }

    [Theory(DisplayName = "Teste de exceção para validação de processo de seleção onde nome não pode ser vazio")]
    [InlineData("Maria;João;Fernanda;Felipe;Maurício;Mayara", null)]
    public void TestSelectionProcessValidationException(string selectedPeople, string name)
    {
        Action action = () => new SelectionProcessValidation().ValidateName(selectedPeople, name);
        action.Should().Throw<ArgumentException>();
    }
}
