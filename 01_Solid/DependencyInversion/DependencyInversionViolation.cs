namespace SOLID.DependencyInversion.Violation;

// Low-level module that exposes its internal storage.
public class Relationships
{
    // Public so that Research can read it directly: this is the leak.
    public List<(Person, Relationship, Person)> Relations { get; } = [];

    public void AddParentAndChild(Person parent, Person child)
    {
        Relations.Add((parent, Relationship.Parent, child));
        Relations.Add((child, Relationship.Child, parent));
    }
}

// Violates DIP: the high-level module depends directly on the low-level class
// AND on how it stores data (a list of tuples). If Relationships switches to a
// dictionary or a database, Research breaks.
public class Research
{
    public Research(Relationships relationships)
    {
        Console.WriteLine("John's children:");
        foreach (var (parent, relationship, child) in relationships.Relations)
        {
            if (parent.Name == "John" && relationship == Relationship.Parent)
            {
                Console.WriteLine(child.Name);
            }
        }
    }
}
