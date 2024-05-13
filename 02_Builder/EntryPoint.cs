using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Builder
{
/* 
 * Builder: is a separate component when piecewise construction is complicated
 * Category: Creational Pattern
 * Built-in example is the string builder.
 */
    internal class EntryPoint
    {
        static void Main(string[] args)
        {
            // Fluent Builder
            //FluentBuilder.Test();

            // Recursive Generics >> used to solve the problem of inheritence in the fluent builder pattern
            //RecursiveGenerics.Test();

            // functional builder >> in this code I try to extend the functionality of a class without
            // breaking the open closed principle and without using inheritance and using extension
            // methods.
            //FunctionalBuilderDemo.Test();

            // Faceted Builder >> used when you split up the building proccess into facets
            // you can wrap them in a facade pattern.
            FacetedBuilder.Test();

        }
    }
   
}
