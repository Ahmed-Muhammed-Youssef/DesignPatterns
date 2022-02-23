using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Factories
{
    public class FactoryMethod
    {
        public static void Test()
        {
            Point point1 = Point.NewCartesianPoint(1, 2);
            Point point2 = Point.NewPolarPoint(5, Math.PI/2);
            Console.WriteLine(point1);
            Console.WriteLine(point2);
        }
    }

    public class Point
    {
        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        // you can also make async initialization with the factory method
        public static async Task<Point> NewCartesianPointAsync(double x, double y)
        {
            await Task.Delay(1000);
            return new Point(x, y);
        }
        public static Point NewPolarPoint(double rho, double theta)
        {

            return new Point(rho * Math.Sin(theta), rho * Math.Cos(theta));
        }
        public static async Task<Point> NewPolarPointAsync(double rho, double theta)
        {
            await Task.Delay(1000);
            return new Point(rho * Math.Sin(theta), rho * Math.Cos(theta));
        }
        /* 
         * another way is to use factory class
         * factory classes achieve the single separation of concern principle
         * we can use it as a normal class but the problem is we want to prevent our api consumer from
         * accessing the constructor so it should be private. we can make the constructor internal sothat no one 
         * can access the constructor outside the assembly but it desn't prevent accessing the constructor 
         * within the assembly.
         */
        public static class Factory
        {
            public static Point NewPolarPoint(double rho, double theta)
            {

                return new Point(rho * Math.Sin(theta), rho * Math.Cos(theta));
            }
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

    }
}
