using SOLID.DependencyInversion;
using SOLID.InterfaceSegregation;
using SOLID.LiskovSubstitution;
using SOLID.OpenClosed;
using SOLID.SingleResponsibility;

namespace SOLID;

internal class Program
{
    static void Main(string[] args)
    {
        Run("Single Responsibility", SingleResponsibilityDemo.Run);
        Run("Open/Closed", OpenClosedDemo.Run);
        Run("Liskov Substitution", LiskovSubstitutionDemo.Run);
        Run("Interface Segregation", InterfaceSegregationDemo.Run);
        Run("Dependency Inversion", DependencyInversionDemo.Run);
    }

    private static void Run(string principle, Action demo)
    {
        Console.WriteLine($"===== {principle} =====");
        demo();
        Console.WriteLine();
    }
}
