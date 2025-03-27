namespace Adapter
{
    public class FileLogger : IFileLogger
    {
        private readonly IFileWriter _fileWriter;
        private readonly Logger _logger;

        public FileLogger(IFileWriter fileWriter, Logger logger)
        {
            _fileWriter = fileWriter;
            _logger = logger;
        }

        public void Log(string message) => WriteLog("[LOG]", () => _logger.Log(message));

        public void Error(string message) => WriteLog("[ERROR]", () => _logger.Error(message));

        public void Warn(string message) => WriteLog("[WARNING]", () => _logger.Warn(message));

        private void WriteLog(string prefix, Action logAction)
        {
            string capturedOutput = CaptureConsoleOutput(logAction);
            _fileWriter.WriteLine($"{prefix} {capturedOutput}");
        }

        private string CaptureConsoleOutput(Action logAction)
        {
            using (StringWriter sw = new StringWriter())
            {
                TextWriter originalOut = Console.Out;
                Console.SetOut(sw);

                logAction.Invoke();

                Console.SetOut(originalOut);
                return sw.ToString();
            }
        }
    }
}
