using Bridge.Implementation;

namespace Bridge.Abstraction
{
    public abstract class Shape
    {
        protected readonly IRenderer _renderer;
        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }
        public abstract void Draw();
    }
}
