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
            Thread th = new Thread(SayHello);
            th.Name = "Hello";
            th.Priority = ThreadPriority.Normal;
            th.Start("Davide");

            // Press RETURN to exit
            Console.ReadLine();
        }

        private static void SayHello(object o)
        {
            Console.WriteLine($"Hello World {o}");
        }
    }
}
