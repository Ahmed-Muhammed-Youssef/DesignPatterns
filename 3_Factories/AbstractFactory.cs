using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Factories
{
    public class AbstractFactory
    {
        public static void Test()
        {
            HotDrinkMachine machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrinks.Coffee, 200);
            drink.Consume();
        } 
    }
    public interface IHotDrink
    {
        public void Consume();
    }
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("coffee");
        }
    }
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("tea");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml");
            return new Tea();
        }
    }
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind coffee beans, boil water, pour {amount} ml");
            return new Coffee();
        }
    }
    public class HotDrinkMachine
    {
        public enum AvailableDrinks
        {
            Tea,
            Coffee
        }
        private Dictionary<AvailableDrinks, IHotDrinkFactory> factories = new Dictionary<AvailableDrinks, IHotDrinkFactory>();
        public HotDrinkMachine()
        {
            foreach (AvailableDrinks drink in Enum.GetValues(typeof(AvailableDrinks)))
            {
                var factory = (IHotDrinkFactory) Activator.CreateInstance(Type.GetType("_3_Factories." + Enum.GetName(typeof(AvailableDrinks), drink)+ "Factory"));
                factories[drink] = factory;
            }
        }
        public IHotDrink MakeDrink(AvailableDrinks drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
}
