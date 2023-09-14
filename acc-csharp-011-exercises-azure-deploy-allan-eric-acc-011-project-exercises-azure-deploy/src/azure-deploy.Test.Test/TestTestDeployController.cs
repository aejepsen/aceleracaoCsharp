using FluentAssertions;

namespace AzureDeploy.Test.Test;

public class TestTestDeployController
{
    [Trait("Category", "1 - Criar Endpoint em Controller e seu teste")]
    [Fact(DisplayName = "TestGetStatusCodeSuccess deve ser executado com sucesso")]
    public void TestSuccessTestGetStatusCodeSuccess()
    {
        Action act = () => new TestDeployController().TestGetStatusCodeSuccess();
        act.Should().NotThrow<Xunit.Sdk.XunitException>();
        act.Should().NotThrow<NotImplementedException>();
    }
}
