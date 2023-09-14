using DevicesFactory.Tools;

namespace DevicesFactory.Trigger
{
    public class Button
    {
        private readonly IDevice _device;

        public Button(IDevice device)
        {
            _device = device;
        }

        public void Trigger()
        {
            if (_device.IsOn)
            {
                _device.TurnOff();
            }
            _device.TurnOn();
        }
    }
}