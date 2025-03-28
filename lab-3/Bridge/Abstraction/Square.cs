using Bridge.Implementation;

namespace Bridge.Abstraction
{
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.Render("Square");
        }
    }
}
