using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Composite
{
    public class GeometricShapes
    {
        public static void Test()
        {
            var drawnings = new GraphicObject {Name = "My Drawing"};
            drawnings.Children.Add(new Square {Color="Red"});
            drawnings.Children.Add(new Circle {Color="Green"});
            drawnings.Children.Add(new Square {Color="White"});

            var group = new GraphicObject();
            group.Children.Add(new Circle{Color="Blue"});
            group.Children.Add(new Square{Color="Pink"});
            drawnings.Children.Add(group);
            System.Console.WriteLine(drawnings);
        }
    }
    internal class GraphicObject 
    {
        public string Color { get; set; }
        public virtual string Name { get; set; } = "Group";
        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;    
        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty: $"{Color} ")
              .AppendLine(Name);
            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }
    internal class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }
    internal class Square : GraphicObject 
    {
        public override string Name => "Square";
    }
}