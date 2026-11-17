namespace SOLID.OpenClosed;

public static class OpenClosedDemo
{
    public static void Run()
    {
        Product[] products =
        [
            new("mobile", Color.blue, Size.small),
            new("mango", Color.green, Size.medium),
            new("bottle", Color.red, Size.medium),
            new("car", Color.red, Size.big),
        ];

        Console.WriteLine("-- Violation: one method per criterion --");
        var productFilter = new Violation.ProductFilter();
        Print("Red and medium products", productFilter.FilterByColorAndSize(products, Color.red, Size.medium));

        Console.WriteLine("-- Following: specifications --");
        var filter = new SpecificationFilter();
        Print("Red products", filter.Filter(products, new ColorSpecification(Color.red)));
        Print("Medium products", filter.Filter(products, new SizeSpecification(Size.medium)));
        Print("Red and medium products", filter.Filter(products, new AndSpecification<Product>(
            new ColorSpecification(Color.red),
            new SizeSpecification(Size.medium))));
    }

    private static void Print(string title, IEnumerable<Product> products)
    {
        Console.WriteLine($"{title}: {string.Join(", ", products.Select(p => p.Name))}");
    }
}
