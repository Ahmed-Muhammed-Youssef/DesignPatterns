using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Builder
{
    public class FunctionalBuilderDemo
    {
        public static void Test()
        {
            var employee = new EmployeeBuilder().Called("Ahmed").WorksAs("Dev").Build();
            Console.WriteLine(employee);
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
    public abstract class FunctioanlBuilder <TData, TSelf>
        where TSelf : FunctioanlBuilder<TData, TSelf>
        where TData : new () // The type argument must have a public parameterless constructor.
    {
        protected readonly List<Func<TData, TData>> actions = new List<Func<TData, TData>>();
        public TData Build() => actions.Aggregate(new TData(), (e, f) => f(e));
        public TSelf Do(Action<TData> action) => AddAction(action);
        private TSelf AddAction(Action<TData> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf) this;
        }
    }
    public sealed class EmployeeBuilder : FunctioanlBuilder<Employee, EmployeeBuilder>
    {
        public EmployeeBuilder Called(string name) => Do(e => e.Name = name);

    }
    /* public sealed class EmployeeBuilder
     {
         private readonly List<Func<Employee, Employee>> actions = new List<Func<Employee, Employee>>();
         public EmployeeBuilder Called(string name) => Do(p => p.Name = name);

         public EmployeeBuilder Do(Action<Employee> action) => AddAction(action);
         private EmployeeBuilder AddAction(Action<Employee> action)
         {
             actions.Add(p =>
             {
                 action(p);
                 return p;
             });
             return this;
         }
         public Employee Build() => actions.Aggregate(new Employee(), (e, f) => f(e));
     }*/
    public static class EmployeeBuilderExtension {
        public static EmployeeBuilder WorksAs(this EmployeeBuilder builder, string position) => builder.Do(e => e.Position = position);
       
    }

}
