namespace Adapter
{
    public class Logger
    {
        public void Log(string message)
        {
            LogMessage(message, ConsoleColor.Green);
        }

        public void Error(string message)
        {
            LogMessage(message, ConsoleColor.Red);
        }

        public void Warn(string message)
        {
            LogMessage(message, ConsoleColor.DarkYellow);
        }

        private void LogMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
