namespace Proxy
{
    public class SmartTextChecker : ISmartTextReader
    {
        private readonly ISmartTextReader _reader;

        public SmartTextChecker(ISmartTextReader reader)
        {
            _reader = reader;
        }
        public char[][] ReadFileToArray(string filePath)
        {
            char[][] array = [];
            try
            {
                Console.WriteLine($"Attempting to read file: {filePath}");
                array = _reader.ReadFileToArray(filePath);
                Console.WriteLine("File was succesfuly opened and read");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while reading file {filePath}: " + ex.Message);
                return array;
            }
            finally
            {
                Console.WriteLine("File was closed");
            }
            int rowCount = array.Length;
            int totalCharacterCount = array.Sum(row => row.Length);

            Console.WriteLine($"Number of rows: {rowCount}");
            Console.WriteLine($"Total number of characters: {totalCharacterCount}");
            return array;
        }
    }
}
