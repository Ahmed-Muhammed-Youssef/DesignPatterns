using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Singleton.Monostate
{
    /*
    * this implementation allows the client to use the constructor
    * but it always has the same satate.
    */
    public class Monostate
    {
        public static void Test ()
        {
            var ceo1 = new CEO();
            ceo1.Name = "Ahmed";
            ceo1.Age = 25;
            var ceo2 = new CEO();
            System.Console.WriteLine($"{nameof(ceo2.Name)}: {ceo2.Name}, {nameof(ceo2.Age)}: {ceo2.Age}");
        }
    }
    internal class CEO 
    {
        private static int age; 
        private static string name;
        public int Age 
        {
            get {return age;} 
            set {age = value;}
        }
        public string Name 
        {
            get {return name;} 
            set {name = value;}
        }
    }
}