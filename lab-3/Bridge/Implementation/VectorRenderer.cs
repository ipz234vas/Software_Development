namespace Bridge.Implementation
{
    public class VectorRenderer : IRenderer
    {
        public void Render(string renderTarget)
        {
            Console.WriteLine($"Drawing {renderTarget} as vector");
        }
    }
}
