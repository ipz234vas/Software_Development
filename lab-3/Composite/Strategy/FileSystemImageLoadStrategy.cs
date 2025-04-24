namespace Composite.Strategy
{
    public class FileSystemImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string path)
        {
            Console.WriteLine($"Loading image({path}) from local file system...");
        }
    }
}
