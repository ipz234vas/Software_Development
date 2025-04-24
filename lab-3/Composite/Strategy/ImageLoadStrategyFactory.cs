namespace Composite.Strategy
{
    public static class ImageLoadStrategyFactory
    {
        public static IImageLoadStrategy GetByImageSource(string source)
        {
            bool isHttpUrl = Uri.TryCreate(source, UriKind.Absolute, out var uri) &&
                             uri.Scheme.StartsWith("http", StringComparison.OrdinalIgnoreCase);

            if (isHttpUrl)
            {
                return new NetworkImageLoadStrategy();
            }

            return new FileSystemImageLoadStrategy();
        }

    }

}
