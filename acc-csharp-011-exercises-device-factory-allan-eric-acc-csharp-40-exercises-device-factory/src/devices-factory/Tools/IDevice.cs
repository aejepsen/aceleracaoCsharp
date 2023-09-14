// A interface IDevice deve ter os métodos TurnOn() e TurnOff(), ambos retornando void e a propriedade IsOn

namespace DevicesFactory.Tools
{
    public interface IDevice
    {
        bool IsOn { get; set;}
        void TurnOn();
        void TurnOff();
    }
}