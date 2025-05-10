namespace Composite.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
