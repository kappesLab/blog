using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ThreadPoolWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(DoStuff, "Davide");
            Console.WriteLine("Io sono nel thread pricipale.");

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoStuff(object o)
        {
            Console.WriteLine($"Ciao {o}, Io sono un thread del 'ThreadPool'");
            Thread.Sleep(500);
        }
    }
}
