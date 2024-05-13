using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9_Decorator
{
    public class CustomStringBuilder
    {
        public static void Test()
        {
            var cb = new MyStringBuilder();

            // using the existing functionality
            cb.AppendLine("class test")
              .AppendLine("{")
              .Append("}");
            System.Console.WriteLine(cb);

            // using the newly added functionality
            MyStringBuilder s = "Hello";
            s += " World";
            System.Console.WriteLine(s);
        }
    }
    internal class MyStringBuilder
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        // most of the code can be auto-generated using resharpper but it will need some 
        // modification as it doesn't understand fluent interfaces.

        // Existing functionality
        public MyStringBuilder Clear()
        {
            _stringBuilder.Clear();
            return this;
        }
        public MyStringBuilder AppendLine(string line)
        {
            _stringBuilder.AppendLine(line);
            return this;
        }
        public MyStringBuilder Append(string s)
        {
            _stringBuilder.Append(s);
            return this;
        }
        public override string ToString()
        {
            return _stringBuilder.ToString();
            
        }
        // new Functionality
        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            return msb.Append(s);

        }
        public static MyStringBuilder operator + (MyStringBuilder msb, string s)
        {
            return msb.Append(s);;
        }
    }
}