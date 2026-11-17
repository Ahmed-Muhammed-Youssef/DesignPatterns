namespace _2_Builder;

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
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
    }
}
public class PersonBuilder
{
    protected Person person = new();
    public Person Build() => person;
}
// TSelf = the final builder type. Methods return TSelf so chaining keeps the most-derived type.
public class PersonInfoBuilder<TSelf> : PersonBuilder
    where TSelf : PersonInfoBuilder<TSelf>
{
    public TSelf Called(string name)
    {
        person.Name = name;
        return (TSelf)this;
    }
}

// Passes TSelf straight up (not PersonJobBuilder<TSelf>), so Called() also returns the
// final builder. With more levels, methods from every level can then be chained in any order.
public class PersonJobBuilder<TSelf> : PersonInfoBuilder<TSelf>
    where TSelf : PersonJobBuilder<TSelf>
{
    public TSelf WorksAs(string position)
    {
        if (string.IsNullOrWhiteSpace(position))
        {
            throw new ArgumentException($"'{nameof(position)}' cannot be null or whitespace.", nameof(position));
        }
        person.Position = position;
        return (TSelf)this;
    }
}

// Closes the loop: "I am the final type, so every method returns me."
public class Builder : PersonJobBuilder<Builder>
{
}
