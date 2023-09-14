using DevicesFactory.Tools;
using Xunit;

namespace DevicesFactory.Test
{
    public class BellTest
    {
        [Fact]
        public void TestBellIsInstanceOfIDevice()
        {
            //Escreva um teste que verifique se,
            //classe 'Bell' foi injetada via interface,
            //checando se ele � do tipo 'IDevice'
            
            var bell = new Bell();
            Assert.IsAssignableFrom<IDevice>(bell);

            
        }

        [Fact]
        public void TestBellTurnOnWhenBellIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOn()' da classe 'Bell' quando a propriedade 'IsOn' � false,
            //o valor da propriedade 'IsOn' ser� true
            var bell = new Bell();
            bell.TurnOn();
            Assert.True(bell.IsOn);
        }

        [Fact]
        public void TestBellTurnOnWhenBellIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOn()' da classe 'Bell' quando a propriedade 'IsOn' � 'true',
            //ser� disparado uma exce��o com a mensagem 'Bell is already on'
            var bell = new Bell();
            bell.TurnOn();
            Assert.Throws<InvalidOperationException>(() => bell.TurnOn());

        }

        [Fact]
        public void TestBellTurnOffWhenBellIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOff()' da classe 'Bell' quando a propriedade 'IsOn' � true,
            //o valor da propriedade 'IsOn' ser� false
            var bell = new Bell();
            bell.TurnOff();
            Assert.False(bell.IsOn);
        }

        [Fact]
        public void TestBellTurnOffWhenBellIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOff()' da classe 'Bell' quando a propriedade 'IsOn' � 'false',
            //ser� disparado uma exce��o com a mensagem 'Bell is already off'
            var bell = new Bell();
            bell.TurnOff();
            Assert.Throws<InvalidOperationException>(() => bell.TurnOff());

        }

        [Fact]
        public void TestBellTurnOnAndTurnOffSequentially()
        {
            //Escreva um teste que verifique se,
            //ao chamar em sequ�ncia os m�todos 'TurnOn()' e 'TurnOff()' da classe 'Bell',
            //o valor da propriedade 'IsOn' ser� false
            var bell = new Bell();
            bell.TurnOn();
            bell.TurnOff();
            Assert.False(bell.IsOn);
            
        }
    }
}
