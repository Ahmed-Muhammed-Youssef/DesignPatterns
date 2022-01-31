using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Builder
{

    public static class RecursiveGenerics
    {
        public static void Test()
        {
            var builder = new Builder();
            builder.Called("Ahmed").WorksAs("Dev");
            Console.WriteLine(builder.Build());
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
    public class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build() => person;
    }
    public class PersonInfoBuilder <Tderived> : PersonBuilder
        where Tderived : PersonInfoBuilder<Tderived>
    {
        public Tderived Called (string name)
        {
            person.Name = name;
            return (Tderived)this;
        }

    }
    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>>
        where T : PersonJobBuilder<T>
    {
        public T WorksAs (string position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException($"'{nameof(position)}' cannot be null or whitespace.", nameof(position));
            }
            person.Position = position;
            return (T)this;
        }
    }
    public class Builder: PersonJobBuilder<Builder>
    {

    }
}
