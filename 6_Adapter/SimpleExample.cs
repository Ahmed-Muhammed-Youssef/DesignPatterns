using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_Adapter.SimpleExample
{
    public class SimpleExample
    {
        public static void Test ()
        {
            var adaptee = new IncompatibleOldClass();
            ITarget target = new Adabter(adaptee);
            System.Console.WriteLine("now the target client can use the old class: ");
            System.Console.WriteLine(target.GetRequest());
        }   
    }
    internal interface ITarget 
    {
        string GetRequest();
    }
    internal class IncompatibleOldClass
    {
        public string GetSpecificRequest()
        {
            return "Specific Request...";
        }
    }
    internal class Adabter : ITarget 
    {
        // we use a reference to access the old incomaptible class
        // which is assigned by a constructor
        private readonly IncompatibleOldClass _adaptee;
        public Adabter(IncompatibleOldClass ic)
        {
            if(ic == null)
            {
                throw new ArgumentNullException(paramName: nameof(ic));
            }
            _adaptee = ic;
        }
        // the modern implementation
        public string GetRequest()
        {
            // here we modify the params to adapt it with the old class.
            return _adaptee.GetSpecificRequest();
        }
    }
}