namespace SchoolLogin.Test.Test;

public class TestTestTokenGenerator
{
        [Trait("Category", "1 - Crie o serviço gerador de Token")]
        [Fact(DisplayName = "TestTokenGeneratorSuccess deve ser executado com sucesso")]       
        public void TestSuccessTestTokenGeneratorSuccess()
        {   
            Action act = () =>  new TestTokenGenerator().TestTokenGeneratorSuccess();
            act.Should().NotThrow<Xunit.Sdk.XunitException>();
        } 

        [Trait("Category", "1 - Crie o serviço gerador de Token")]
        [Fact(DisplayName = "TestTokenGeneratorKeysSuccess deve ser executado com sucesso")]         
        public void TestSuccessTestTokenGeneratorKeysSuccess()
        {          
            Action act = () => new TestTokenGenerator().TestTokenGeneratorKeysSuccess();
            act.Should().NotThrow<Xunit.Sdk.XunitException>();
        }
}