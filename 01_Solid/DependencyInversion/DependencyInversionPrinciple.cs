namespace SOLID.DependencyInversion;

// Following DIP: Research (high-level) and Relationships (low-level) both depend on
// the IRelationshipBrowser abstraction, not on each other.
public enum Relationship
{
    Parent,
    Child,
    Sibling
}
public class Person
{
    public required string Name { get; set; }
}
public interface IRelationshipBrowser
{
    IEnumerable<Person> FindAllChildrenOf(string name);
}
// low-level
public class Relationships : IRelationshipBrowser
{
    private readonly List<(Person, Relationship, Person)> relations = [];
    public void AddParentAndChild(Person parent, Person child)
    {
        relations.Add((parent, Relationship.Parent, child));
        relations.Add((child, Relationship.Child, parent));
    }

    public IEnumerable<Person> FindAllChildrenOf(string name)
    {
        return from child in relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent)
               select child.Item3;
    }
}

// high-level
public class Research
{
    public Research(IRelationshipBrowser relationshipBrowser)
    {
        Console.WriteLine("John's children:");
        foreach (var child in relationshipBrowser.FindAllChildrenOf("John"))
        {
            Console.WriteLine(child.Name);
        }
    }
}
