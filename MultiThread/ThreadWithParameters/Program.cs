using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWith_Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(DoStuff);
            th.Name = "ThreadStuff";
            th.Priority = ThreadPriority.Normal;
            th.Start("Davide");

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static void DoStuff(object o)
        {
            Console.WriteLine($"Ciao mondo da {o}!");
        }
    }
}
