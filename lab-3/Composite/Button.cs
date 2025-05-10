using Composite.State;

namespace Composite
{
    public class Button : LightContainerElementNode
    {
        public IButtonState State { get; set; }

        public Button() : base("button", "inline-block", "paired")
        {
            State = new ButtonReleasedState(this);
        }

        public void Press()
        {
            Console.WriteLine("Attempt of pressing button...");
            State.Press();
        }

        public void Release()
        {
            Console.WriteLine("Attempt of releasing button...");
            State.Release();
        }
    }
}
