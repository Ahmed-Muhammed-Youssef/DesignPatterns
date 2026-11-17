namespace SOLID.LiskovSubstitution.Violation;

// Implicit contract: Width and Height change independently.
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle()
    {
    }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Area => Width * Height;

    public override string ToString()
    {
        return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
    }
}

// Violates LSP: a square "is a" rectangle mathematically, but not behaviorally.
// Setting one side silently changes the other, breaking Rectangle's contract.
public class Square : Rectangle
{
    public override int Width
    {
        set { base.Width = base.Height = value; }
    }

    public override int Height
    {
        set { base.Height = base.Width = value; }
    }
}

// Client code written against Rectangle. It's correct for a Rectangle,
// but gives a wrong answer when handed a Square.
public static class RectangleResizer
{
    public static void Resize(Rectangle rectangle)
    {
        rectangle.Width = 5;
        rectangle.Height = 4;

        const int expected = 20;
        var status = rectangle.Area == expected ? "OK" : "BROKEN";
        Console.WriteLine($"{rectangle.GetType().Name}: expected area {expected}, got {rectangle.Area} -> {status}");
    }
}
