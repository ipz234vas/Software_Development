namespace Composite.Command
{
    public class SetTextCommand : ICommand
    {
        private readonly Input _input;
        private readonly string _newText;
        private readonly string _previusText;

        public SetTextCommand(Input input, string newText)
        {
            _input = input;
            _newText = newText;
            _previusText = input.Text;
        }
        public void Execute()
        {
            _input.Text = _newText;
        }

        public void Undo()
        {
            if (_previusText != null)
                _input.Text = _previusText;
        }
    }
}
