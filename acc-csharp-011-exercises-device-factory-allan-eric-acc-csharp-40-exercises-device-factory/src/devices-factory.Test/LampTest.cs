using DevicesFactory.Tools;
using Xunit;

namespace DevicesFactory.Test
{
    public class LampTest
    {
        [Fact]
        public void TestLampIsInstanceOfIDevice()
        {
            //Escreva um teste que verifique se,
            //classe 'Lamp' foi injetada via interface,
            //checando se ele � do tipo 'IDevice'
            var lamp = new Lamp();
            Assert.IsAssignableFrom<IDevice>(lamp);
        }

        [Fact]
        public void TestLampTurnOnWhenLampIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOn()' da classe 'Lamp' quando a propriedade 'IsOn' � 'false',
            //o valor da propriedade 'IsOn' ser� true
            var lamp = new Lamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void TestLampTurnOnWhenLampIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOn()' da classe 'Lamp' quando a propriedade 'IsOn' � 'true',
            //ser� disparado uma exce��o com a mensagem 'Lamp is already on'
            var lamp = new Lamp();
            lamp.TurnOn();
            Assert.Throws<InvalidOperationException>(() => lamp.TurnOn());
        }

        [Fact]
        public void TestLampTurnOffWhenLampIsOn()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOff()' da classe 'Lamp' quando a propriedade 'IsOn' � 'true',
            //o valor da propriedade 'IsOn' ser� false
            var lamp = new Lamp();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void TestLampTurnOffWhenLampIsOff()
        {
            //Escreva um teste que verifique se,
            //ao chamar o m�todo 'TurnOff()' da classe 'Lamp' quando a propriedade 'IsOn' � 'false',
            //ser� disparado uma exce��o com a mensagem 'Lamp is already off'
            var lamp = new Lamp();
            lamp.TurnOff();
            Assert.Throws<InvalidOperationException>(() => lamp.TurnOff());
        }

        [Fact]
        public void TestLampTurnOnAndTurnOffSequentially()
        {
            //Escreva um teste que verifique se,
            //ao chamar em sequ�ncia os m�todos 'TurnOn()' e 'TurnOff()' da classe 'Lamp',
            //o valor da propriedade 'IsOn' ser� 'false'
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
        }
    }
}
