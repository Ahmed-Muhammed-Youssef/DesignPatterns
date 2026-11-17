namespace SOLID.InterfaceSegregation.Violation;

// Violates ISP: one "fat" interface forces every device to implement
// printing, scanning, and faxing, whether it can do them or not.
public interface IMachine
{
    void Print();
    void Scan();
    void Fax();
}

// Fine here: this device really can do everything IMachine asks for.
public class MultiFunctionPrinter : IMachine
{
    public void Print() => Console.WriteLine($"{nameof(MultiFunctionPrinter)}: printing");
    public void Scan() => Console.WriteLine($"{nameof(MultiFunctionPrinter)}: scanning");
    public void Fax() => Console.WriteLine($"{nameof(MultiFunctionPrinter)}: faxing");
}

// The problem: this printer can only print, but IMachine forces it to implement
// Scan and Fax anyway. All it can do is throw, and callers only find out at runtime.
public class OldPrinter : IMachine
{
    public void Print() => Console.WriteLine($"{nameof(OldPrinter)}: printing");
    public void Scan() => throw new NotSupportedException($"{nameof(OldPrinter)} cannot scan.");
    public void Fax() => throw new NotSupportedException($"{nameof(OldPrinter)} cannot fax.");
}
