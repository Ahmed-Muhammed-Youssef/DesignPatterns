using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
* this example uses flyweigth design pattern to avoid storing redundent strings instead 
* it stores an index of the stored string.
*/
namespace _11_Flyweight
{
    public static class RepeatingUserNames
    {
        public static void Test()
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ =>RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var users = new List<User> ();
            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User($"{firstName} {lastName}"));
                }
            }
            System.Console.WriteLine($"number of first names + last names without Flyweight design pattern: {users.Count() * 2}");
            System.Console.WriteLine($"number of first + last names with Flyweight design pattern:{User.stringsCache.Count()}");
        }
        private static string RandomString ()
        {
            Random rand = new Random();
            return new string(
                Enumerable.Range(0, 10)
                .Select(i => (char)('a' + rand.Next(26)))
                .ToArray()
            );
        }
    }
    internal class User 
    {
        private int[] names;
        static public List<string> stringsCache = new List<string>();
        public User(string fullName)
        {
            names = fullName.Split(' ').Select(GetOrAdd).ToArray()?? throw new ArgumentNullException(paramName: nameof(fullName));
        }
        public string FullName => string.Join(" ", names.Select(i => stringsCache[i]));
        private static int GetOrAdd(string s)
        {
            int i = stringsCache.IndexOf(s);
            if(i != -1)
            {
                return i;
            }
            else 
            {
                stringsCache.Add(s);
                return stringsCache.Count() - 1;
            }
        }
    }
}