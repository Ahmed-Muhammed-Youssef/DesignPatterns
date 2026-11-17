namespace SOLID.LiskovSubstitution;

// Following LSP: the shared contract only promises what every shape can honor.
public interface IShape
{
    int Area { get; }
}

public class Rectangle(int width, int height) : IShape
{
    public int Width { get; } = width;
    public int Height { get; } = height;

    public int Area => Width * Height;

    public override string ToString() => $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
}

// Square no longer inherits from Rectangle, so it can't break Rectangle's contract.
public class Square(int side) : IShape
{
    public int Side { get; } = side;

    public int Area => Side * Side;

    public override string ToString() => $"{nameof(Side)}: {Side}";
}
