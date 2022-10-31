using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace _4_Prototype.CopyThroughSerialization
{
    /*
    * works fine with legacy code without any modification, it serializes
    * the object data in a memory stream then it deserialize the data in 
    * a new object. Its downside is the memory cost.
    */
    public class CopyThroughSerialization
    {
        public static void Test()
        {
            var ahmed = new Person(new []{"Ahmed Youssef"}, new Address("al nasser st", 123));
            var omar = ahmed.DeepCopyXml();
            omar.Names = new []{"Omar Youssef"};
            omar.Address.HouseNumber = 50;
            Console.WriteLine(ahmed);
            Console.WriteLine(omar);
        }
    }
    internal static class ExtenstionMethods
    {
        // works only with serializable objects
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = (T)formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }
        // works with any type of objects but must have paramaterless constructors
        public static T DeepCopyXml<T> (this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }
    // [Serializable]
    public class Person
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
        public override string ToString(){
            return $"{nameof(Names)}: {string.Join(", ", Names)}, {nameof(Address)}, {Address}";
        }
    }
    // [Serializable]
    public class Address
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public Address(){}
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