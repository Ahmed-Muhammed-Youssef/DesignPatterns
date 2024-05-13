using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5_Singleton.SingletonImplementation
{
    /*
    * this implementation is done by perventing the client from using the constructor
    * so he only can use one instance.
    */
    public class SingletonImplementation
    {
        public static void Test()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            System.Console.WriteLine(db.GetPopulation("cairo"));
            System.Console.WriteLine(db2.GetPopulation("tokyo"));

        }    
    }
    internal interface IDatabase 
    {
        int GetPopulation(string name);
    }
    internal class SingletonDatabase : IDatabase
    {
        private static SingletonDatabase instance = new SingletonDatabase(); // It will get initialized only once (the first call).
        public static SingletonDatabase  Instance => instance;
        private Dictionary<string, int> capitals;
        private SingletonDatabase()
        {
            System.Console.WriteLine("Initializing Database...");
            capitals = new Dictionary<string, int>() {{"cairo", 8000000}, {"tokyo", 30000000}, {"london", 15000000}};
        }
        public int GetPopulation (string name)
        {
            return capitals[name];
        }
    }
}