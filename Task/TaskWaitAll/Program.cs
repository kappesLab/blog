using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskwaitAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Task output1 = Task.Factory.StartNew(DoLongOperation1);
            Task output2 = Task.Factory.StartNew(DoLongOperation2);
            Task output3 = Task.Factory.StartNew(DoLongOperation3);
            Task output4 = Task.Factory.StartNew(DoLongOperation4);

            Console.WriteLine("Sono nel metodo chiamante PRIMA dell'attesa.");

            Task.WaitAll(output1, output2, output3, output4);

            Console.WriteLine("Sono nel metodo chiamante DOPO dell'attesa.");

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static void DoLongOperation1()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine("Io sono DolongOperation #1.");
        }

        private static void DoLongOperation2()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine("Io sono DolongOperation #2.");
        }
        private static void DoLongOperation3()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine("Io sono DolongOperation #3.");
        }

        private static void DoLongOperation4()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine("Io sono DolongOperation #4.");
        }
    }
}
