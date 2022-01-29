using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    /*
     * Definitin: high level parts of the system should not depend on low level parts of 
     * the system directly, instesd they should depend on some kind of abstraction. it ensures
     * that you encapsulate the enternals of each class.
     * high-level modules should not depend on low-level; both should depend on abstractions 
     * abstractions should not depend on details; details should depend on abstractions
     */
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }
    public class Person
    {
        public string Name { get; set; }
    }
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
    // low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
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
            Console.WriteLine("john children: ");
            foreach (var child in relationshipBrowser.FindAllChildrenOf("John"))
            {
                Console.WriteLine(child.Name);
            }
        }
    }
}
