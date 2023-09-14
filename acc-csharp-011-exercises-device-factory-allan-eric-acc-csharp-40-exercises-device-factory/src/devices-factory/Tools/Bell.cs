using System;

namespace DevicesFactory.Tools
{
    public class Bell : IDevice
    {
        public bool IsOn { get; set; } = false;

        public void TurnOn()
        {
            if (IsOn)
            {
                throw new InvalidOperationException("Bell is already on");
            }
            IsOn = true;
        }

        public void TurnOff()
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("Bell is already off");
            }
            IsOn = false;
        }
    }
}

