using DevicesFactory.Tools;
using DevicesFactory.Trigger;
using Xunit;

namespace DevicesFactory.Test
{
    public class SwitcherTest
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(13, true)]
        [InlineData(20, false)]
        public void TestSwitcherCanRecieveDifferentDevices(int timesTriggered, bool expectedValue)
        {
            //timestriggered = número de vezes que o método 'Trigger' de 'Switcher' é acionado
            //expectedValue = o valor final da propriedade 'IsOn' dos dispositivos acionados
            var lamp = new Lamp();
            var switcher = new Switcher
            {
                Device = lamp
            };
            for (int i = 0; i < timesTriggered; i++)
            {
                switcher.Trigger();
            }
            Assert.Equal(expectedValue, expectedValue);
        }
    }
}
