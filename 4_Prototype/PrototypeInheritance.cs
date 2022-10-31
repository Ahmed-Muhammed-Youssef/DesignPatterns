using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_Prototype.PrototypeInheritance
{
    /*
    */
    public class PrototypeInheritance
    {
        public static void Test()
        {
            var Jaun = new Employee(new[]{"Jaun Youssef"}, new Address("M3ady", 65), 50000);
            var Jaisse = new Employee();
            Jaun.CopyTo(Jaisse);
            Jaisse.Names = new[]{"Jaisse Youssef"};
            Jaisse.Address.StreetName = "Ambaba";
            System.Console.WriteLine(Jaun);
            System.Console.WriteLine(Jaisse);
        }

    }
    internal interface IDeepCopyable<T>
    where T : new ()
    {
        void CopyTo(T target);
        T DeepCopy() 
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }
    internal class Address : IDeepCopyable<Address>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public Address() 
        {

        }
        public Address(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public void CopyTo(Address target)
        {
            target.HouseNumber = HouseNumber;
            target.StreetName = StreetName;
        }
        public override string ToString(){
            return $"{nameof(StreetName)}: {StreetName},{nameof(HouseNumber)}: {HouseNumber}";
        }
    }
    internal class Employee : Person, IDeepCopyable<Employee>
    {
        public int Salary { get; set; }
        public Employee(){}
        public Employee (string[] names, Address address, int salary): base(names, address)
        {
            Salary = salary;
        }
        public void CopyTo(Employee target){
            target.Salary = Salary;
            base.CopyTo(target);
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }
    }
    internal class Person : IDeepCopyable<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }
        public Person()
        {
        }
        public Person(string[] names, Address address) 
        {
            if(address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            if(names == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }
            this.Address = address;
            this.Names = names;
        }
        public void CopyTo(Person target)
        {
            target.Names = Names;
            target.Address = ((IDeepCopyable<Address>)Address).DeepCopy();
        }
        public override string ToString(){
            return $"{nameof(Names)}: {string.Join(", ", Names)}, {nameof(Address)}, {Address}";
        }
    }
}