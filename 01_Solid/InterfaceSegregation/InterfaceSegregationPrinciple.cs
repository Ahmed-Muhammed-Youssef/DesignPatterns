namespace SOLID.InterfaceSegregation;

// Following ISP: one small interface per capability.
public interface IPrinter
{
    public void Print();
}

public interface IScanner
{
    public void Scan();
}

// Implements only what it can do. No fake Scan method.
public class OldPrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine($"{nameof(OldPrinter)}: printing");
    }
}

public class Scanner : IScanner
{
    public void Scan()
    {
        Console.WriteLine($"{nameof(Scanner)}: scanning");
    }
}

// A device with both capabilities, built by composing existing ones.
// It implements both interfaces and delegates each call to the object that does the work.
// (This is composition/delegation. It isn't the Decorator pattern: a decorator wraps an object
// of the same interface to add behavior to it.)
public class ModernPrinter : IPrinter, IScanner
{
    private readonly IPrinter printer;
    private readonly IScanner scanner;

    public ModernPrinter(IPrinter printer, IScanner scanner)
    {
        this.printer = printer;
        this.scanner = scanner;
    }

    public void Print()
    {
        printer.Print();
    }

    public void Scan()
    {
        scanner.Scan();
    }
}
