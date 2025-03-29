using System.Text.RegularExpressions;

namespace Proxy
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private readonly ISmartTextReader _reader;
        public SmartTextReaderLocker(ISmartTextReader reader)
        {
            _reader = reader;
        }

        public char[][] ReadFileToArray(string filePath)
        {
            string pattern = @"limited";

            if (Regex.IsMatch(filePath, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }

            return _reader.ReadFileToArray(filePath);
        }
    }
}
