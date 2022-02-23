using System;

namespace _3_Factories
{
    /* 
     * 
     * Category: Creational Pattern
     * Definition: there's two types of factories,
     * the first type and the most common one is the factory method,
     * the seconde one and quite rare to encounter is the abstract factory (a factory class).
     * In general the main point of factories to initialize an object (the wholesale not piecewise like 
     * Builders).
     * 
     */
    internal class EntryPoint
    {
        static void Main(string[] args)
        {
            // FactoryMethod.Test();
            AbstractFactory.Test();
        }
    }
}
