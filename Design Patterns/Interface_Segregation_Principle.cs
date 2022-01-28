using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
   /* Definition: Interfaces should be segregated so that nobody who implements 
    * your interface has to implement functions which they don't actually need.
    */
   public interface IPrinter
    {
        public void Print();
    }
    public interface IScaner
    {
        public void Scan();
    }
    public class OldPrinter : IPrinter
    {
        public void Print()
        {
            //prints
        }
    }
    public class ModenPrinter : IPrinter, IScaner
    {
        private readonly IPrinter printer;
        private readonly IScaner scaner;

        public ModenPrinter(IPrinter printer, IScaner scaner)
        {
            this.printer = printer;
            this.scaner = scaner;
        }
        public void Print()
        {
           printer.Print();
        }

        public void Scan()
        {
            scaner.Scan();
        }
        //this is called the decorator design pattern
    }
}
