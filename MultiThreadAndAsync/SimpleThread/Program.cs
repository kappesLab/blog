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
            Thread th = new Thread(SayHello);
            th.Name = "Hello";
            th.Priority = ThreadPriority.Normal;
            th.Start();

            // Press RETURN to exit
            Console.ReadLine();
        }

        private static void SayHello()
        {
            Console.WriteLine("Hello World");
        }

    }
}
