namespace SOLID.OpenClosed.Violation;

// Violates OCP: every new filter criterion (or combination of criteria) means
// MODIFYING this class and adding another method. The combinations grow fast:
// color, size, color + size, and adding "weight" would add three more.
public class ProductFilter
{
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var product in products)
            if (product.Color == color)
                yield return product;
    }

    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach (var product in products)
            if (product.Size == size)
                yield return product;
    }

    public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
    {
        foreach (var product in products)
            if (product.Color == color && product.Size == size)
                yield return product;
    }
}
