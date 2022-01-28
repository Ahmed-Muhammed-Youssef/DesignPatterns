using System;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Single Resposibility Principle
            /* var j = new Journal();
             j.AddEntery("I learnt single resposibility today");
             j.AddEntery("I practised some problem solving.");
             Console.WriteLine(j);

             var filename = @"c:\temp\myjournal.txt";
             Persistence.SaveToFile(j, filename);
             Console.WriteLine(Persistence.LoadFile(filename));*/

            //Open Closed Principle
            /*Product[] products = new Product[]
            {
                new Product("mobile", Color.blue, Size.small),
                new Product("mango", Color.green, Size.medium),
                new Product("bottle", Color.red, Size.medium),
                new Product("car", Color.red, Size.big)
            };
            var filter = new SpecificationFilter();
            Console.WriteLine("*Red Products:");
            foreach (var item in filter.Filter(products, new ColorSpecification(Color.red)))
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("*Medium Size Products");
            foreach (var item in filter.Filter(products, new SizeSpecification(Size.medium)))
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("*Red and Medium Size Products");
            foreach (var item in filter.Filter(products, new AndSpecification<Product> (
                new ColorSpecification(Color.red),
                new SizeSpecification(Size.medium)
                ) ))
            {
                Console.WriteLine(item.Name);
            }*/

            //Liskov Substitution Principle
            /*Rectangle r = new Rectangle(20, 30);
            Rectangle square = new Square();
            square.Width = 10;
            Console.WriteLine(r);
            Console.WriteLine(square);*/
        }
    }
}
