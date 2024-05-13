using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_Prototype.CopyConstructor
{
    /*
    * coming from c++, what is the problem with it?
    * to implement the copy constructor, every class that our class depends on (e.g composition & parent classes) must have 
    * implemented it before, Or we will break the OCP by editing these classes.
    */

    public class CopyConstructor
    {
        public static void Test()
        {
            var ahmed = new Person(new []{"Ahmed Youssef"}, new Address("al nasser st", 123));
            var omar = new Person(ahmed);
            omar.Names = new []{"Omar Youssef"};
            omar.Address.HouseNumber = 50;
            Console.WriteLine(ahmed);
            Console.WriteLine(omar);
        }
    }
    internal class Person
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }
        public Person(Person person)
        {
            if(person == null){
                throw new ArgumentNullException(paramName: nameof(person));
            }
            Names = person.Names;
            Address = new Address(person.Address);
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
    internal class Address
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public Address(Address address)
        {
            if(address == null){
                throw new ArgumentNullException(paramName: nameof(address));
            }
            StreetName = address.StreetName;
            HouseNumber = address.HouseNumber;
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