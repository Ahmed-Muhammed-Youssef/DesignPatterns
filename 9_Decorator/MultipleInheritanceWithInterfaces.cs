using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9_Decorator
{

    /*
    * Decorator pattern is used to mimic multiple inheritance in c# as it's not supported. 
    */
    public class MultipleInheritanceWithInterfaces
    {
        public static void Test()
        {
            var dragon = new Dragon();
            dragon.Weight = 100;
            dragon.Fly();
            dragon.Crawl();
        }
    }
    internal interface IBird 
    {
        int Weight { get; set; }
        void Fly();
    }
    internal class Bird : IBird 
    {
        public int Weight { get; set; }
        public void Fly()
        {
            System.Console.WriteLine($"Flying, my weight is {Weight}");
        }
    }
    internal interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }
    internal class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            System.Console.WriteLine($"Crawling, my weight is {Weight}");
        }
    } 
    internal class Dragon : IBird, ILizard
    {
        private readonly Lizard _lizard = new Lizard();
        private readonly Bird _bird = new Bird();
        private int weight;
        public int Weight 
        { 
            get 
            {
                return weight;
            }   
            set 
            {
                weight = value;
                _lizard.Weight = value;
                _bird.Weight = value;
            } 
        }
        public void Fly()
        {
            _bird.Fly();
        }
        public void Crawl()
        {
            _lizard.Crawl();
        }
    }
}