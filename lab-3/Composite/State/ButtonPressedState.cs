using Composite.Observer;

namespace Composite.State
{
    public class ButtonPressedState : IButtonState
    {
        private readonly Button _button;

        public ButtonPressedState(Button button)
        {
            _button = button;
        }
        public void Press()
        {
            Console.WriteLine("Button is already pressed!");
        }

        public void Release()
        {
            Console.WriteLine("Button is succesfuly released!");

            _button.InvokeEvent(EventType.Click);

            _button.State = new ButtonReleasedState(_button);
        }
    }
}
