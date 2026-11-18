namespace _5_Singleton.PerThreadSingleton;

public class PerThreadSingleton
{
    public static void Test()
    {
        // Real threads, not tasks: two tasks can run on the same thread-pool thread,
        // and then they would (correctly) share one instance, hiding the point of the demo.
        var t1 = new Thread(() =>
        {
            System.Console.WriteLine("t1 " + ThreadSingleton.ThreadSingletonInstance.Id);
        });
        var t2 = new Thread(() =>
        {
            System.Console.WriteLine("t2 " + ThreadSingleton.ThreadSingletonInstance.Id);
            System.Console.WriteLine("t2 " + ThreadSingleton.ThreadSingletonInstance.Id);
        });

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
}
internal class ThreadSingleton 
{
    private static ThreadLocal<ThreadSingleton> threadInstance = new ThreadLocal<ThreadSingleton>(
        () => new ThreadSingleton()
    );
    private ThreadSingleton() 
    {
        Id = Thread.CurrentThread.ManagedThreadId;
    }
    // Value is never null here: the factory above always creates an instance.
    public static ThreadSingleton ThreadSingletonInstance => threadInstance.Value!;
    public int Id;
}