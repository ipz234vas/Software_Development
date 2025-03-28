using Bridge.Implementation;

namespace Bridge.Abstraction
{
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.Render("Circle");
        }
    }
}
