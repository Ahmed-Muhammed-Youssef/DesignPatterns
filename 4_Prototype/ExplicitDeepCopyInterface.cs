using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_Prototype.ExplicitDeepCopyInterface
{
    /*
    */
    public class ExplicitDeepCopyInterface
    {
        public static void Test(){
            var ahmed = new Person(new []{"Ahmed Youssef"}, new Address("al nasser st", 123));
            var omar = ahmed.DeepCopy();
            omar.Names = new []{"Omar Youssef"};
            omar.Address.HouseNumber = 50;
            Console.WriteLine(ahmed);
            Console.WriteLine(omar);
        } 
    }
    interface IDeepCopy<T>
    {
        public T DeepCopy();
    }
    internal class Person : IDeepCopy<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }
        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
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
        public override string ToString(){
            return $"{nameof(Names)}: {string.Join(", ", Names)}, {nameof(Address)}, {Address}";
        }
    }
    internal class Address : IDeepCopy<Address>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
        public Address(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public override string ToString(){
            return $"{nameof(StreetName)}: {StreetName},{nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}