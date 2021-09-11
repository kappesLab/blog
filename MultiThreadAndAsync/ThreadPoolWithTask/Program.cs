using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolWithTask
{

    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(DoStuff, "Davide");
            task.Start();
            //task.Wait();

            Console.WriteLine("Io sono nel thread pricipale.");

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoStuff(object name)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Ciao {name}, Io sono in un thread del 'ThreadPool'");
        }

    }
}
