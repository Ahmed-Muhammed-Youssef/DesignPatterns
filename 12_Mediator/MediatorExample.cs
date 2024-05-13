namespace _12_Mediator;

public abstract class MediatorBase
{
    public abstract void Send(string message, ColleagueBase colleague);
}

public abstract class ColleagueBase(MediatorBase mediator)
{
    private readonly MediatorBase _mediator = mediator;

    public virtual void Send(string message)
    {
        _mediator.Send(message, this);
    }
    public abstract void Receive(string message);
}

public class Colleague1(MediatorBase mediator) : ColleagueBase(mediator)
{
    public override void Receive(string message) => Console.WriteLine($"Colleague1 received {message}");
}
public class Colleague2(MediatorBase mediator) : ColleagueBase(mediator)
{
    public override void Receive(string message) => Console.WriteLine($"Colleague2 received {message}");
}

public class ConcreteMediator : MediatorBase
{
    public Colleague1? Colleague1;
    public Colleague2? Colleague2;

    public override void Send(string message, ColleagueBase colleague)
    {
        if (colleague == Colleague1)
        {
            Colleague2?.Receive($"{message} from {nameof(Colleague1)}");
        }
        else if (colleague == Colleague2)
        {
            Colleague1?.Receive($"{message} from {nameof(Colleague2)}");
        }
    }
}
internal class MediatorExample
{
    public static void Test()
    {
        var mediator = new ConcreteMediator();
        var c1 = new Colleague1(mediator);
        var c2 = new Colleague2(mediator);

        mediator.Colleague1 = c1;
        mediator.Colleague2 = c2;

        c1.Send("Hello");
        c2.Send("Hi");

        c1.Send("Bye");
        c2.Send("Bye bye");

    }
}


