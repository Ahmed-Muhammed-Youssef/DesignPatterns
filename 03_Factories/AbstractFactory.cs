namespace _3_Factories;

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
        // Convention: each enum value X has a class named XFactory in this namespace.
        // Reflection finds and creates it, so adding a drink needs no change here.
        foreach (var drink in Enum.GetValues<AvailableDrinks>())
        {
            var typeName = $"{typeof(HotDrinkMachine).Namespace}.{drink}Factory";
            var type = Type.GetType(typeName)
                ?? throw new InvalidOperationException($"No factory class named '{typeName}' for {drink}.");
            factories[drink] = (IHotDrinkFactory)Activator.CreateInstance(type)!;
        }
    }
    public IHotDrink MakeDrink(AvailableDrinks drink, int amount)
    {
        return factories[drink].Prepare(amount);
    }
}
