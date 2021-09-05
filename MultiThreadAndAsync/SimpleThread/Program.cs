using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(DoStuff);
            th.Name = "ThreadStuff";
            th.Priority = ThreadPriority.Normal;
            th.Start();

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static void DoStuff()
        {
            Console.WriteLine("Ciao mondo!");
        }

    }
}
