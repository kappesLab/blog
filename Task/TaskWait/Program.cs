using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task output = Task.Factory.StartNew(DoLongOperation);
            output.Wait();

            Console.WriteLine($"output.Status = {output.Status}");

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static void DoLongOperation()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine("Io sono il lavoro del task.");
        }
    }
}
