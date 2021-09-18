using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCreationLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() =>
            {
                // Simulates a long-term operation
                Thread.Sleep(500);
                Console.WriteLine("Io sono il lavoro del task.");
            });
            task.Start();

            Console.WriteLine("Io sono nel metodo chiamante.");

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
