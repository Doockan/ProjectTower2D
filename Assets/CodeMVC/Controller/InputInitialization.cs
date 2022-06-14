using CodeMVC.Interface;
using CodeMVC.UserInput;

namespace CodeMVC.Controller
{
    internal sealed class InputInitialization : IInitialization
    {
        
        private IUserInputProxy _InputHorizontal;
        private IUserInputProxy _InputVertical;

        public InputInitialization(IGameFactory factory)
        {
            var inputJoystick = factory.CreateJoystick();
            var joystick = inputJoystick.GetComponentInChildren<DynamicJoystick>();
            _InputHorizontal = new MobileInputHorizontal(joystick);
            _InputVertical = new MobileInputVertical(joystick);
        }
        
        public void Initialization()
        {
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_InputHorizontal, _InputVertical);
            return result;
        }
    }
}
