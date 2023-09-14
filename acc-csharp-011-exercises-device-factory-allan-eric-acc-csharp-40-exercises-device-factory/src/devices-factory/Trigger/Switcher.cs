using DevicesFactory.Tools;

namespace DevicesFactory.Trigger
{
    public class Switcher
    {
        private IDevice _device;

        public IDevice Device
        {
            set => _device = value;
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