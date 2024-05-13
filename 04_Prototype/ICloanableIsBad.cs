using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_Prototype.ICloanableIsBad
{
    /*
    * ICloneable is bad because it returns an object which requires casting and this is dangerious,
    * and Clone() does shallow copying which force us to implement Clone to each class referenced in
    * the parent class.
    */
    public static class ICloanableIsBad {
        public static void Test(){
            var ahmed = new Person(new []{"Ahmed Youssef"}, new Address("al nasser st", 77));
            var omar = (Person)ahmed.Clone();
            omar.Names = new []{"Omar Youssef"};
            omar.Address.HouseNumber = 50;
            Console.WriteLine(ahmed);
            Console.WriteLine(omar);
        }
    }
    internal class Person : ICloneable 
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }
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
        public object Clone(){
            return new Person(Names, (Address)Address.Clone());
        }
    }
    internal class Address : ICloneable
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        
        public Address(string streetName, int houseNumber) 
        {
            this.StreetName = streetName;
            this.HouseNumber = houseNumber;
        }
        public override string ToString(){
            return $"{nameof(StreetName)}: {StreetName},{nameof(HouseNumber)}: {HouseNumber}";
        }
        public object Clone(){
            return new Address(StreetName, HouseNumber);
        }
    }
}