using Bridge.Abstraction;
using Bridge.Implementation;

Shape triangle = new Triangle(new RasterRenderer());
Shape circle = new Circle(new VectorRenderer());
Shape square = new Square(new RasterRenderer());

triangle.Draw();
circle.Draw();
square.Draw();