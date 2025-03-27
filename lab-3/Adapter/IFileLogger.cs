namespace Adapter
{
    public interface IFileLogger
    {
        void Error(string message);
        void Log(string message);
        void Warn(string message);
    }
}