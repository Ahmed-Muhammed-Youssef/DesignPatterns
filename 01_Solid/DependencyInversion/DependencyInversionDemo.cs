namespace SOLID.DependencyInversion;

public static class DependencyInversionDemo
{
    public static void Run()
    {
        var parent = new Person { Name = "John" };
        var child1 = new Person { Name = "Mary" };
        var child2 = new Person { Name = "Chris" };

        Console.WriteLine("-- Violation: Research reads Relationships' internal list --");
        var leakyRelationships = new Violation.Relationships();
        leakyRelationships.AddParentAndChild(parent, child1);
        leakyRelationships.AddParentAndChild(parent, child2);
        _ = new Violation.Research(leakyRelationships);

        Console.WriteLine("-- Following: Research depends on IRelationshipBrowser --");
        var relationships = new Relationships();
        relationships.AddParentAndChild(parent, child1);
        relationships.AddParentAndChild(parent, child2);
        _ = new Research(relationships);
    }
}
