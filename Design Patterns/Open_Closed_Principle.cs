using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    /*
     * Definition: classes are closed to modification but open to extension.
     * which means when you want to add a new feature you will need to write a new class rather than 
     * modifying an existing class
     * the desing pattern used in this example to achieve OCP is the specification design pattern.
     */
    public enum Color
    {
        red, green, blue
    }
    public enum Size
    {
        small, medium, big
    }
   public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Product(string name, Color color, Size size)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }

    }
    public interface ISpecification<T>
    {
        bool IsValid(T product);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsValid(Product product)
        {
            return product.Color == color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsValid(Product product)
        {
            return product.Size == size;
        }
    }
    interface IFilter<T> { 
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class SpecificationFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsValid(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first ?? throw new ArgumentNullException(nameof(first));
            this.second = second ?? throw new ArgumentNullException(nameof(second));
        }
        public bool IsValid(T product)
        {
            return first.IsValid(product) && second.IsValid(product);
        }
    }
}
