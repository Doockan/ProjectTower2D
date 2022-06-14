using System;
using CodeMVC.Interface;

namespace CodeMVC.UserInput
{
    internal sealed class MobileInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        private readonly DynamicJoystick _joystick;

        public MobileInputVertical(DynamicJoystick joystick)
        {
            _joystick = joystick;
        }
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(_joystick.Vertical);
        }
    }
}