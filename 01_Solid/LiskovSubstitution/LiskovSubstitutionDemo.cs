namespace SOLID.LiskovSubstitution;

public static class LiskovSubstitutionDemo
{
    public static void Run()
    {
        Console.WriteLine("-- Violation: Square inherits Rectangle --");
        // Both are "Rectangles" to the resizer, but only one behaves like one.
        Violation.RectangleResizer.Resize(new Violation.Rectangle());
        Violation.RectangleResizer.Resize(new Violation.Square());

        Console.WriteLine("-- Following: both implement IShape --");
        IShape[] shapes = [new Rectangle(5, 4), new Square(4)];
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} ({shape}): area {shape.Area}");
        }
    }
}
