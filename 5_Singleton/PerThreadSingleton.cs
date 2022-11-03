using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace _5_Singleton.PerThreadSingleton
{
    public class PerThreadSingleton
    {
        public static void Test()
        {
            var t1 = Task.Factory.StartNew(()=>
            {
                System.Console.WriteLine("t1 "+ ThreadSingleton.ThreadSingletonInstance.Id);
            });
            var t2 = Task.Factory.StartNew(()=>
            {
                System.Console.WriteLine("t2 "+ ThreadSingleton.ThreadSingletonInstance.Id);
                System.Console.WriteLine("t2 "+ ThreadSingleton.ThreadSingletonInstance.Id);
            });
            
            Task.WaitAll(t1, t2);
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
        public static ThreadSingleton ThreadSingletonInstance => threadInstance.Value; 
        public int Id;
    }
}