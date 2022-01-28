using System;
using System.Collections.Generic;
using System.IO;

/*
 * Definition: Every class should have a single reason to change. which means each class only
 * has a single responsibility.
 * As a byproduct you will get separation of concerns.
 */
namespace SOLID
{
    public class Journal
    {
        private readonly List<string> enteries = new List<string>();

        public int AddEntery(string entery)
        {
            enteries.Add(entery);
            return enteries.Count;
        }
        public void RemoveEnteryAt(int index)
        {
            enteries.RemoveAt(index);
        }
        public override string ToString()
        {
            return String.Join(Environment.NewLine, enteries);
        }
    }
    public static class Persistence
    {
        public static void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }
        public static string LoadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
