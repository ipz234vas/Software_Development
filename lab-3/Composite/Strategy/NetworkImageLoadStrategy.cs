using System.IO;

namespace Composite.Strategy
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string url)
        {
            Console.WriteLine($"Loading image({url}) from network...");
        }
    }
}
