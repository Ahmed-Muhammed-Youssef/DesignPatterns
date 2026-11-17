namespace SOLID.InterfaceSegregation;

public static class InterfaceSegregationDemo
{
    public static void Run()
    {
        Console.WriteLine("-- Violation: one fat IMachine interface --");
        // IMachine says every device can scan, so the compiler lets us call it.
        Violation.IMachine[] machines = [new Violation.MultiFunctionPrinter(), new Violation.OldPrinter()];
        foreach (var machine in machines)
        {
            try
            {
                machine.Scan();
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"Error: {ex.Message} (IMachine promised it could)");
            }
        }

        Console.WriteLine("-- Following: small interfaces --");
        var modernPrinter = new ModernPrinter(new OldPrinter(), new Scanner());

        // Only IScanner devices fit here. Adding an OldPrinter would be a compile error, not a crash.
        IScanner[] scanners = [new Scanner(), modernPrinter];
        foreach (var scanner in scanners)
        {
            scanner.Scan();
        }

        modernPrinter.Print();
    }
}
