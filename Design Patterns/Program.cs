using System;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntery("I learnt single resposibility today");
            j.AddEntery("I practised some problem solving.");
            Console.WriteLine(j);

            var filename = @"c:\temp\myjournal.txt";
            Persistence.SaveToFile(j, filename);
            Console.WriteLine(Persistence.LoadFile(filename));
        }
    }
}
