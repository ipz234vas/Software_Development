namespace Composite.State
{
    public class ButtonReleasedState : IButtonState
    {
        private readonly Button _button;

        public ButtonReleasedState(Button button)
        {
            _button = button;
        }

        public void Press()
        {
            Console.WriteLine("Button is succesfuly pressed!");
            _button.State = new ButtonPressedState(_button);
        }

        public void Release()
        {
            Console.WriteLine("Button is not pressed!");
        }
    }
}
