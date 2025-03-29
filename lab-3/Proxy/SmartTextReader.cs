namespace Proxy
{
    public class SmartTextReader : ISmartTextReader
    {
        public char[][] ReadFileToArray(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            List<char[]> lines = new List<char[]>();

            foreach (string line in File.ReadLines(filePath))
            {
                lines.Add(line.ToCharArray());
            }

            return lines.ToArray();
        }
    }
}
