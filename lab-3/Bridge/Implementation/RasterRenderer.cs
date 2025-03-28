namespace Bridge.Implementation
{
    public class RasterRenderer : IRenderer
    {
        public void Render(string renderTarget)
        {
            Console.WriteLine($"Drawing {renderTarget} as pixels");
        }
    }
}
