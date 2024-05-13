using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _7_Bridge
{
    public class BridgeExample
    {
        public static void Test() 
        {
            var circle = new Circle (new WindowsRenderer(), 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();

        }
    }
    // implementation
    internal interface IRenderer 
    {
        void RenderCircle(float radius);
    }
    internal class AndroidRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            System.Console.WriteLine($"Drawing a circle on android platform of radius {radius}");
        }
    }
    internal class WindowsRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            System.Console.WriteLine($"Drawing a circle on windows platform of radius {radius}");
        }
    }
    // abstraction/ interface
    internal abstract class Shape 
    {
        protected readonly IRenderer renderer;
        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(paramName: nameof(renderer));
        }
        public abstract void Draw ();
        public abstract void Resize(float factor);
    }
    internal class Circle : Shape
    {
        private float radius;
        public Circle (IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }
        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
}